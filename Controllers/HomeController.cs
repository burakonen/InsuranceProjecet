using ClosedXML.Excel;
using InsuranceProject.Context;
using InsuranceProject.DataContext;
using InsuranceProject.DataMethods;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceProject.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        ApplicationContext context = new ApplicationContext();

        public GetAllCategories _getAllCategories;

        public HomeController(GetAllCategories getAllCategories)
        {
            _getAllCategories = getAllCategories;
        }




        public IActionResult Index(int id)
        {

            var Categories = _getAllCategories.GetCategories();

            var quickOffer = context.QuickOffers.Include(s => s.InsuranceList).ToList();
            var mainPageImage = context.MainPageImages.ToList();

            var model = new CategoryAndInsuranceViewModel()
            {
                QuickOffers = quickOffer,
                MainImage = mainPageImage,
                Categories = Categories
            };

            return View(model);
        }

     

        public async Task<IActionResult> PolicyPages(string url)
        {

            if(url == null)
            {
                return NotFound();
            }

            var advantagesCount = await context.InsuranceLists.Where(a => a.SEOURL == url).Include(s => s.Advantages).Select(a => new SelectAdvantagesCount() { AdvantCount = a.Advantages.Count()}).FirstOrDefaultAsync();
            var seoUrl = await context.InsuranceLists.Where(a => a.SEOURL == url).Select(a => new SelectSeoUrl() {SeoUrl = a.SEOURL }).FirstOrDefaultAsync();
            var model = await context.InsuranceLists.Where(a => a.SEOURL == url).Include(a => a.GuaranteeName.Where(s => s.IsDeleted == false)).Include(s => s.Guarantees.Where(s => s.IsDeleted == false)).Include(i => i.PageDescriptions).Include(p => p.PageImages).Include( s => s.Advantages).Select(o =>
            new SelectInsuranceListDetails()
            {
                Advantages = o.Advantages.Select(s => new SelectAdvantages() { Name = s.Name, İcon = s.Icon}),
                Guarantee = o.Guarantees.Where(s => s.IsDeleted == false).Select(o => new SelectGuarantee() { Guarantee = o.Name, GuaraneeNames = o.GuaranteeNames.Select(a => new SelectGuaranteeName() {Name = a.Name, GuaranteeDescription = a.GuaranteeDescription}) }),
                PageDescriptions = o.PageDescriptions.Select(s => new SelectPageDescriptions() { Header = s.Header, Descriptions = s.Description}),
                PageImage = o.PageImages.Select(p => new SelectPageImage() {FileName = p.Name, Description = p.Description, PageHeader = p.PageHeader, Number = p.PhoneNumber }),
                MainFaqs = o.MainFaqs.Select(a => new SelectMainFaqs() {Name = a.Name, Faqs = a.Faqs.Select(s => new SelectFaqs() {Answer = s.Answer, Question = s.Question}) })


            }).ToListAsync();



            var categoryGroups = _getAllCategories.GetCategories();


            var entity = new InsuranceListDetailsWM()
            {
                InsuranceListDetails = model,
                CategoriesByGroups = categoryGroups,
                Url = seoUrl,
                AdvantagesCount = advantagesCount
            };
           

            return View(entity);
        }

        
        [Route("bireysel/teklif-al/{url}")]
        public IActionResult InsuranceForm(string url)
        {

            if(url == null)
            {
                return NotFound();
            }
            var model = context.InsuranceLists.Where(a => a.SEOURL == url).Include(s => s.PageDescriptions).Include(a => a.Category).ThenInclude(i => i.GroupsAndCategories.Where(a => a.Groups.Name == "bireysel")).ThenInclude(a => a.Groups).FirstOrDefault();
            
            return View(Tuple.Create<UserWM, InsuranceFormWM>(new UserWM(), new InsuranceFormWM() {InsuranceList = model }));
        }



        [HttpPost]
        public async Task<IActionResult> UserInsuranceCreate([Bind(Prefix = "Item1")] UserWM user, int InsuranceListId, int GroupsId)
        {
            
            if(ModelState.IsValid)
            {
                var entity = new Users()
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    TCKN = user.TCKN,
                    DateOfBirth = user.Birthday,
                    InsuranceListId = InsuranceListId,
                    Date = DateTime.Now
                };

                var GroupsAndUsers = new GroupsAndUsers()
                {
                    UsersId = entity.Id,
                    GroupsId = GroupsId
                };

               

                SuccessMessage("Talebiniz başarıyla oluşturuldu.En yakın zamanda tarafınıza geri dönüş sağlanacaktır.");
                await context.Users.AddAsync(entity);
                await context.SaveChangesAsync();


                await context.GroupsAndUsers.AddAsync(GroupsAndUsers);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(user);
            

        }

        public void SuccessMessage(string message)
        {
            var messages = new AlertMessage()
            {
                Message = message,
            };

            TempData["AlertMessage"] = JsonConvert.SerializeObject(messages);
        }



        [HttpGet]
        public IActionResult Search(string query)
        {
            ViewBag.searchName = query;

            var GetInfo =  context.InsuranceLists.Where(i => i.Name.Contains(query)).Include(a => a.PageImages).Include(s => s.PageDescriptions).Select(a => new SelectInsurance() {
            
                InsuranceName = a.Name,
                Url = a.SEOURL,
                Description = a.PageDescriptions.Select(s => new SelectPageDescriptions() { Descriptions = s.Description}).ToList(),
                Image = a.PageImages.Select(S => new SelectPageImage() { FileName = S.Name}).ToList(),
            
            }).ToList();

            ViewBag.GetResultCount = context.InsuranceLists.Where(i => i.Name.Contains(query)).Count();


            var model = new SearchWm()
            {
                ResultOfSearch = GetInfo
            };
            return View(model);
        }

        
     



    }
}
