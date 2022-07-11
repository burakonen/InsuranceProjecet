using ClosedXML.Excel;
using InsuranceProject.Areas.Admin.Model;
using InsuranceProject.Context;
using InsuranceProject.DataContext;
using InsuranceProject.DataMethods;
using InsuranceProject.Migrations;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Area.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]

    public class AdminController : Controller
    {

        ApplicationContext context = new ApplicationContext();

        public GetAllCategories _getAllCategories;
        public GetGroupName _getGroupNames;
        public GetAllUser _getAllUser;



        public AdminController(GetAllCategories getAllCategories, GetGroupName groupNames, GetAllUser getAllUser)
        {
            _getAllCategories = getAllCategories;
            _getGroupNames = groupNames;
            _getAllUser = getAllUser;
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
        [Route("admin/ana-sayfa")]
        public IActionResult Index()
        {
            
            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();
            var GetAllUsers = _getAllUser.GetUsers();
            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();

            ViewBag.AllUserCount = context.GroupsAndUsers.Include(i => i.Users).Count();
            ViewBag.IndividualUserCount = context.GroupsAndUsers.Where(a => a.Groups.Name == "BİREYSEL").Include(i => i.Users).Count();
            ViewBag.CorporateUserCount = context.GroupsAndUsers.Where(a => a.Groups.Name == "KURUMSAL").Include(i => i.Users).Count();

            return View(Tuple.Create<IndexWM, CategoryModel>(new IndexWM(){   
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,
                CategoriesAndInsuranceList = individualcategoryGroups,
                CorporatecategoryGroups = CorporatecategoryGroups,
                Users = GetAllUsers,
              
            }, 
            new CategoryModel()));
        }


        [Route("/admin/policeler/{url}")]
        public IActionResult InsurancePolicy(string url)
        {
            if (url == null)
            {
                return NotFound();
            }


            var insurancePolicies = context.InsuranceLists.Where(a => a.SEOURL == url).Include(s => s.PageImages).FirstOrDefault();
            var insurancePoliciesUsers = context.Users.Where(i => i.InsuranceListId == insurancePolicies.Id).ToList();

            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();
            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();


            return View(Tuple.Create<IndexWM, CategoryModel, PageImageModel>(new IndexWM()
            {
                CategoriesAndInsuranceList = individualcategoryGroups,
                CorporatecategoryGroups = CorporatecategoryGroups,
                InsuranceLists = insurancePolicies,
                InsuranceListUsers = insurancePoliciesUsers,
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,

            }, new CategoryModel(), new PageImageModel()));
        }




        [HttpGet]
        [Route("/admin/policeler/{url}/teminat-bilgileri")]
        public IActionResult InsurancePolicyGuaranteeNameEdit(string url)
        {
            if (url == null)
            {
                return NotFound();
            }

            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();

            var insurancePolicies = context.InsuranceLists.Where(a => a.SEOURL == url).Include(s => s.Guarantees.Where(s => s.IsDeleted == false)).FirstOrDefault();

            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();


            return View(Tuple.Create<IndexWM, GuaranteePostWM>(new IndexWM()
            {
                        IndividualGroup = individualGroupName,
                        CorporateGroup = corporateGroupName,
                        InsuranceLists = insurancePolicies, 
                        CategoriesAndInsuranceList = individualcategoryGroups, 
                        CorporatecategoryGroups = CorporatecategoryGroups 
            }, new GuaranteePostWM()));

        }




        [HttpPost]
        public async Task<IActionResult> InsurancePolicyNameEdit([Bind(Prefix ="Item1")] IndexWM model, int insuranceId)
        {


            if (ModelState.IsValid)
            {
                var entity = context.InsuranceLists.Find(insuranceId);
                entity.Name = model.InsuranceLists.Name;
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> GuaranteePost([Bind(Prefix = "Item2")] GuaranteePostWM model, int guaranteeId)
        {


            if (ModelState.IsValid)
            {
                var guarantee = await context.Guarantees.FindAsync(guaranteeId);


                guarantee.Name = model.Name;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);


        }





        [HttpPost]
        public async Task<IActionResult> NewGuarenteCreate([Bind(Prefix = "Item2")] GuaranteePostWM model, int insuranceId)
        {
            if (ModelState.IsValid)
            {
                var guarantee = new Guarantees()
                {
                    Name = model.Name,
                    Date = DateTime.Now,
                    IsDeleted = false,
                    InsuranceListId = insuranceId
                };
                await context.Guarantees.AddAsync(guarantee);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }




        public async Task<IActionResult> getguarantee(int id)
        {

            var guarantees = await context.Guarantees.Where(i => i.Id == id).FirstOrDefaultAsync();
            var jsonGuarantee = JsonConvert.SerializeObject(guarantees);
            return Json(jsonGuarantee);
        }


        [Route("/admin/policeler/teminat-detayları/{id}")]
        public async Task<IActionResult> GuaranteeNameDetails(int id)
        {
            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();


            var guaranteeName = await context.Guarantees.Where(i => i.Id == id).Include(s => s.GuaranteeNames.Where(s => s.IsDeleted == false)).Include(s => s.InsuranceList).ToListAsync();


            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();


            return View(Tuple.Create<IndexWM, GuaranteeNameDetails>(new IndexWM()
            {
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,
                CategoriesAndInsuranceList = individualcategoryGroups, 
                CorporatecategoryGroups = CorporatecategoryGroups }, 
                new GuaranteeNameDetails() { Guarantees = guaranteeName }));
        }




        [HttpPost]
        public IActionResult deleteGuarantee(int id)
        {

            var guaranteeName = context.Guarantees.Where(i => i.Id == id).FirstOrDefault();
            if (guaranteeName != null)
            {
                guaranteeName.IsDeleted = true;
                context.SaveChangesAsync();
            }

            return Ok();

        }



        [HttpGet]
        public async Task<IActionResult> getguaranteename(int id)
        {

            var guaranteeName = await context.GuaranteeNames.Where(i => i.Id == id).FirstOrDefaultAsync();
            var jsonGuaranteeName = JsonConvert.SerializeObject(guaranteeName);


            return Json(jsonGuaranteeName);

        }




        [HttpPost]
        public async Task<IActionResult> guaranteeeditpost([Bind(Prefix = "Item2")] GuaranteeNameDetails model, int guaranteeNameId)
        {

            if (ModelState.IsValid)
            {
                var guaranteeNames = await context.GuaranteeNames.FindAsync(guaranteeNameId);
                guaranteeNames.Name = model.Name;
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);

        }


        [HttpGet]
        [Route("/admin/policeler/{url}/sayfa-aciklamasi")]
        public async Task<IActionResult> InsurancePolicyPageDescrition(string url)
        {

            if (url == null)
            {
                return NotFound();
            }

            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();

            var insurancePolicies = await context.InsuranceLists.Where(a => a.SEOURL == url).Include(k => k.PageDescriptions).Select(a => new PageDescriptionsWM() {
            
               PageDescWM = a.PageDescriptions.Select(s => new PageDesc() {Header = s.Header, Description = s.Description, Id = s.Id }).FirstOrDefault()
            
            
            }).FirstOrDefaultAsync();



            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();


            return View(Tuple.Create<IndexWM, CategoryModel, PageDescriptionModel>(new IndexWM()
            {
                //InsuranceLists = insurancePolicies,
                CategoriesAndInsuranceList = individualcategoryGroups,
                CorporatecategoryGroups = CorporatecategoryGroups,
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,

            }, new CategoryModel(), new PageDescriptionModel() {PageDesc = insurancePolicies} ));

        }


        [HttpPost]
        public async Task<IActionResult> PageDescription(string pageHeader, string cktext, int pageId)
        {

            var page = await context.PageDescriptions.FindAsync(pageId);
            page.Header = pageHeader;
            page.Description = cktext;
            await context.SaveChangesAsync();

            return RedirectToAction("Index");

        }



        [HttpPost]
        public async Task<IActionResult> InsurancePolicyPageImageEdit([Bind(Prefix ="Item3")] PageImageModel model, int pageImageId)
        {

           if(ModelState.IsValid)
            {
                var pageImage = await context.PageImages.FindAsync(pageImageId);


                Random rastgele = new Random();
                int rndImamge = rastgele.Next();
                string fileName = Path.GetFileNameWithoutExtension(model.PageImage.FileName);
                string extension = Path.GetExtension(model.PageImage.FileName);
                var newİmageName = "Image-" + rndImamge.ToString() + extension;
                string path = Path.Combine("wwwroot/img/InsuranceImage", newİmageName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.PageImage.CopyToAsync(fileStream);
                }
                pageImage.Name = "img/InsuranceImage" + newİmageName;



                return RedirectToAction("Index");
            }
            return View(model);

        }


        [Route("/admin/policeler/{url}/sik-sorulanlar")]
        public async Task<IActionResult> InsurancePolicyFaqs(string url)
        {

            if (url == null)
            {
                return NotFound();
            }

            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();


            var insurancePolicies = await context.InsuranceLists.Where(a => a.SEOURL == url).Include(s => s.MainFaqs.Where(s => s.IsDeleted == false)).Include(i => i.Faqs).FirstOrDefaultAsync();
            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();

            return View(Tuple.Create<IndexWM, MainFaqsWM>(new IndexWM()
            {
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,
                CategoriesAndInsuranceList = individualcategoryGroups, 
                CorporatecategoryGroups = CorporatecategoryGroups, 
                InsuranceLists = insurancePolicies, }, new MainFaqsWM()));

        }




        [HttpPost]
        public async Task<IActionResult> NewMainFaqsCreate([Bind(Prefix ="Item2")]  MainFaqsWM model, int InsuranceListId)
        {
           if(ModelState.IsValid)
            {
                var mainfaqs = new MainFaqs()
                {
                    Name = model.Name,
                    Date = DateTime.Now,
                    IsDeleted = false,
                    InsuranceListId = InsuranceListId
                };
                await context.MainFaqs.AddAsync(mainfaqs);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public async Task<IActionResult> MainFaqsDetails(int id)
        {

            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();


            var insurancePolicies = await context.MainFaqs.Where(a => a.Id == id).Include(i => i.Faqs).Include(s => s.InsuranceList).FirstOrDefaultAsync();
            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();

            return View(Tuple.Create<IndexWM, FaqsEditWM>(new IndexWM()
            {
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,
                CategoriesAndInsuranceList = individualcategoryGroups, 
                CorporatecategoryGroups = CorporatecategoryGroups, 
                MainFaqs = insurancePolicies, }, new FaqsEditWM()));
        }




        [HttpPost]
        public async Task<IActionResult> NewFaqsCreate(FaqsWM model)
        {
            var faqs = new InsuranceProject.Context.Faq()
            {
                Question = model.Question,
                Answer = model.Answer,
                Date = DateTime.Now,
                IsDeleted = false,
                InsuranceListId = model.InsuranceListId,
                MainFaqsId = model.MainFaqsId 
            };
            await context.Faqs.AddAsync(faqs);
            await context.SaveChangesAsync();
            var jsonMainFaqs = JsonConvert.SerializeObject(faqs);
            return Json(jsonMainFaqs);
        }


        [HttpGet]
        public async Task<IActionResult> MainFaqsGet(int id)
        {

            var mainFaqs = await context.MainFaqs.Where(i => i.Id == id).FirstOrDefaultAsync();
            var jsonMainFaqs = JsonConvert.SerializeObject(mainFaqs);
            return Json(jsonMainFaqs);
        }



        [HttpPost]
        public async Task<IActionResult> MainFaqsEditPost([Bind(Prefix = "Item2")] MainFaqsWM model, int mainfaqsId)
        {

            if (ModelState.IsValid)
            {

                var mainFaqs = await context.MainFaqs.FindAsync(mainfaqsId);
                mainFaqs.Name = model.Name;
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);

        }



        [HttpPost]
        public async Task<IActionResult> FaqsEdit([Bind(Prefix ="Item2")] FaqsEditWM model, int faqsId)
        {

            if(ModelState.IsValid)
            {

                var faqs = await context.Faqs.FindAsync(faqsId);
                faqs.Question = model.Question;
                faqs.Answer = model.Answer;
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> GetFaqs(int id)
        {

            var faqs = await context.Faqs.Where(i => i.Id == id).FirstOrDefaultAsync();
            var jsonfaqs = JsonConvert.SerializeObject(faqs);


            return Json(jsonfaqs);

        }



        [HttpPost]
        public IActionResult deletefaqs(int id)
        {

            var guaranteeName = context.Faqs.Where(i => i.Id == id).FirstOrDefault();
            if (guaranteeName != null)
            {
                guaranteeName.IsDeleted = true;
                context.SaveChangesAsync();
            }

            return Ok();

        }





        [HttpPost]
        public IActionResult deleteMainfaqs(int id)
        {

            var guaranteeName = context.MainFaqs.Where(i => i.Id == id).FirstOrDefault();
            if (guaranteeName != null)
            {
                guaranteeName.IsDeleted = true;
                context.SaveChangesAsync();
            }

            return Ok();

        }




        [HttpPost]
        public IActionResult deleteguaranteename(int id)
        {

            var guaranteeName = context.GuaranteeNames.Where(i => i.Id == id).FirstOrDefault();
            if (guaranteeName != null)
            {
                guaranteeName.IsDeleted = true;
                context.SaveChangesAsync();
            }

            return Ok();

        }



        [Route("/admin/{name}/yeni-police-ekle")]
        public async Task<IActionResult> CreateInsurance(string name)
        {

            if(name == null)
            {
                return NotFound();
            }

            var categoryId = await context.Categories.Where(i => i.Name == name).FirstOrDefaultAsync();


            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();
            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();

            return View(Tuple.Create<IndexWM, CreateInsuranceWM, CategoryModel>(new IndexWM()
            {
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,
                CategoriesAndInsuranceList = individualcategoryGroups, 
                CorporatecategoryGroups = CorporatecategoryGroups, 
                Category = categoryId}, new CreateInsuranceWM(), new CategoryModel() ));

        }




        [HttpPost]
        public async Task<IActionResult> CreateInsurance(string InsurunceName, string editor1, string pageDesc, int categoryId, IFormFile file)
        {

            var insurance = new InsuranceList()
            {
                Name = InsurunceName,
                Date = DateTime.Now,
                IsDeleted = false,
                CategoryId = categoryId
            };
            await context.InsuranceLists.AddAsync(insurance);
            await context.SaveChangesAsync();


            var pageDescription = new PageDescriptions()
            {
                Header = pageDesc,
                Description = editor1,
                Date = DateTime.Now,
                IsDeleted = false,
                InsuranceListId = insurance.Id
            };
            await context.PageDescriptions.AddAsync(pageDescription);
            await context.SaveChangesAsync();


            var random = new Random();
            var extension = Path.GetExtension(file.FileName);
            var newImageName = "Image" + random.ToString() + extension;
            var location = Path.Combine("wwwroot/img/newinsuranceimage", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file.CopyTo(stream);

            var pageImage = new PageImage()
            {
                Name = "img/newinsuranceimage/" + newImageName,
                InsuranceListId = insurance.Id
            };

            await context.PageImages.AddAsync(pageImage);
            await context.SaveChangesAsync();


            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult AddNewGuaranteeName([Bind(Prefix ="Item2")] GuaranteeNameDetails model, int insuranceListId, int guaranteeInputId)
        {


           if(ModelState.IsValid)
            {
                var guaranteeName = new GuaranteeName()
                {
                    Name = model.Name,
                    Date = DateTime.Now,
                    IsDeleted = false,
                    InsuranceListId = insuranceListId,
                    GuaranteesId = guaranteeInputId,
                    GuaranteeDescription = model.Descriptions
                };

                context.GuaranteeNames.AddAsync(guaranteeName);
                context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);


        }



        [HttpPost]
        public async Task<IActionResult> InsurancePolicySeo(string seoValue, int seoId)
        {

            var insuranceList = await context.InsuranceLists.FindAsync(seoId);
            insuranceList.SEOURL = seoValue;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult ExportToExcell(int id)
        {

            var users = context.InsuranceLists.Where(i => i.Id == id).Include(s => s.User).ToList();



            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Firstname";
                foreach (var item in users)
                {
                    foreach (var user in item.User)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = user.Id;
                        worksheet.Cell(currentRow, 2).Value = user.FirstName;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "users.xlsx");
                }

            }

        }



        [HttpPost]
        public IActionResult ExportToExcellUsers()
        {

            var users = context.Users.ToList();



            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Firstname";
                foreach (var item in users)
                {
                    foreach (var user in users)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = user.Id;
                        worksheet.Cell(currentRow, 2).Value = user.FirstName;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "users.xlsx");
                }

            }

        }

    }
}
