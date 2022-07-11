using InsuranceProject.Areas.Admin.Model;
using InsuranceProject.Context;
using InsuranceProject.DataContext;
using InsuranceProject.DataMethods;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {

        ApplicationContext context = new ApplicationContext();

        public GetAllCategories _getAllCategories;
        public GetGroupName _getGroupNames;



        public CategoryController(GetAllCategories getAllCategories, GetGroupName groupNames)
        {
            _getAllCategories = getAllCategories;
            _getGroupNames = groupNames;
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
        [Route("/admin/{name}/kategori/ana-sayfa")]
        public IActionResult Index(string name)
        {

            if(name == null)
            {
                return NotFound();
            }
            var categories = (from g in context.Groups
                              join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                              join c in context.Categories on mcg.CategoryId equals c.Id
                              where g.Name == name 
                              select new SelectCategory()
                              {
                                  CategoryId = c.Id,
                                  Name = c.Name,
                                  CategoryDate= c.Date,
                                  GroupName = g.Name,
                                  GroupId = g.Id,
                                  InsuranceListName = c.InsuranceList.Select(a => new SelectCategoryName() { Name = a.Name })
                              }).ToList();

            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();

            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();

            return View(Tuple.Create<IndexWM, CategoryModel>(new IndexWM() { IndividualGroup = individualGroupName, CorporateGroup = corporateGroupName, CategoriesByGroup = categories, CategoriesAndInsuranceList = individualcategoryGroups, CorporatecategoryGroups = CorporatecategoryGroups, }, new CategoryModel()));
        }


        [HttpGet]
        public async Task<IActionResult> getcategoryname(int id)
        {

            var category = await context.Categories.Where(i => i.Id == id).FirstOrDefaultAsync();
            var jsoncategory = JsonConvert.SerializeObject(category);
            return Json(jsoncategory);
        }


        [HttpPost]
        public async Task<IActionResult> CategoryNameEdit([Bind(Prefix ="Item2")] CategoryModel model, int hiddenCategoryId)
        {

            if (ModelState.IsValid)
            {
                var category = await context.Categories.FindAsync(hiddenCategoryId);
                category.Name = model.Name;
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return View(model);
        }



        [HttpPost]
        public IActionResult deleteCategory(int id)
        {

            var guaranteeName = context.Categories.Where(i => i.Id == id).FirstOrDefault();
            if (guaranteeName != null)
            {
                guaranteeName.IsDeleted = true;
                context.SaveChangesAsync();
            }

            return Ok();

        }


        [Route("/admin/{name}/kategori/kategori-detay")]
        public IActionResult CategoryDetails(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var individualGroupName = _getGroupNames.GetIndividiaulGroupName();
            var corporateGroupName = _getGroupNames.GetCorporateGroupName();

            var categoriesAndInsuruncaList = context.Categories.Where(i => i.Name == name).Include(i => i.InsuranceList).ToList();
            var categoryName = context.Categories.Where(i => i.Name == name).Select(s => new SelectCategoryName() { Name = s.Name }).FirstOrDefault();



            var individualcategoryGroups = _getAllCategories.GetCategories();
            var CorporatecategoryGroups = _getAllCategories.GetCorporateCategorie();

            return View(Tuple.Create<IndexWM, CategoryModel, InsuranceNameEditModel>(new IndexWM()
            { 
                CategoryName = categoryName, 
                CategoriesInsurunceList = categoriesAndInsuruncaList,
                IndividualGroup = individualGroupName,
                CorporateGroup = corporateGroupName,
                CategoriesAndInsuranceList = individualcategoryGroups, 
                CorporatecategoryGroups = CorporatecategoryGroups, }, new CategoryModel(), new InsuranceNameEditModel()));
        }



        [HttpGet]
        public async Task<IActionResult> getinsuruncenamefromcategory(int id)
        {

            var insurance = await context.InsuranceLists.Where(i => i.Id == id).FirstOrDefaultAsync();
            var jsonInsurance = JsonConvert.SerializeObject(insurance);
            return Json(jsonInsurance);
        }


        [HttpPost]
        public async Task<IActionResult> İnsuranceNameEditFromCategory([Bind(Prefix ="Item3")] InsuranceNameEditModel model, int InsurunceId) 
        {

            if (ModelState.IsValid)
            {
                var insurance = await context.InsuranceLists.FindAsync(InsurunceId);
                insurance.Name = model.Name;

                await context.SaveChangesAsync();

                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return View(model);
        }



        [HttpPost]
        public IActionResult deleteInsurance(int id)
        {

            var insurance = context.InsuranceLists.Where(i => i.Id == id).FirstOrDefault();
            if (insurance != null)
            {
                insurance.IsDeleted = true;
                context.SaveChangesAsync();
            }

            return Ok();

        }


        [HttpPost]
        public async Task<IActionResult> addnewcategory([Bind(Prefix = "Item2")] CategoryModel model, int groupId)
        {

            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = model.Name,
                    Date = DateTime.Now,
                    IsDeleted = false,

                };


                SuccessMessage("Kategori bilgileri başarılı bir şekilde oluşturuldu.");
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                var entity = new MapCategoryGroup()
                {
                    CategoryId = category.Id,
                    GroupId = groupId

                };
                await context.MapCategoryGroups.AddAsync(entity);
                await context.SaveChangesAsync();

                return RedirectToAction("Index", "Admin", new { area = "Admin" });


            }
            return View(model);


        }


    }
}
