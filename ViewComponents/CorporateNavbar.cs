using InsuranceProject.DataContext;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.ViewComponents
{
    public class CorporateNavbar: ViewComponent
    {
        ApplicationContext context = new ApplicationContext();

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCategory = RouteData?.Values["id"];
            ViewBag.GroupId = RouteData?.Values["GroupId"];

            var bireysel = context.Groups.Where(i => i.Name == "BİREYSEL").Include(s => s.GroupsAndCategories).ThenInclude(a => a.Category).ThenInclude(s => s.InsuranceList).ToList();
            var kurumsal = context.Groups.Where(i => i.Name == "KURUMSAL").Include(s => s.GroupsAndCategories).ThenInclude(a => a.Category).ThenInclude(s => s.InsuranceList).ToList();

            var groupAndCategories = (from g in context.Groups
                                      join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                                      join c in context.Categories on mcg.CategoryId equals c.Id
                                      where g.Name == "BİREYSEL"
                                      select new SelectCategory()
                                      {
                                          CategoryId = c.Id,
                                          Name = c.Name,
                                          GroupName = g.Name,
                                          GroupId = g.Id,
                                          InsuranceListName = c.InsuranceList.Select(a => new SelectCategoryName() { Name = a.Name, Url = a.SEOURL })
                                      }).ToList();


            var corporateCategories = (from g in context.Groups
                                       join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                                       join c in context.Categories on mcg.CategoryId equals c.Id
                                       where g.Name == "KURUMSAL"
                                       select new SelectCategory()
                                       {
                                           CategoryId = c.Id,
                                           Name = c.Name,
                                           GroupName = g.Name,
                                           GroupId = g.Id,
                                           InsuranceListName = c.InsuranceList.Select(a => new SelectCategoryName() { Name = a.Name, Url = a.SEOURL })
                                       }).ToList();



            var groupsInd = context.Groups.Where(i => i.Name == "BİREYSEL").FirstOrDefault();
            var groupsCor = context.Groups.Where(i => i.Name == "KURUMSAL").FirstOrDefault();
            var groups = context.Groups.ToList();

            var model = new GroupsModel()
            {
                Categories = groupAndCategories,
                CorporateCategories = corporateCategories,
                GroupsInd = groupsInd,
                GroupsCor = groupsCor,
                Groups = bireysel,
                GroupsCorporate = kurumsal

            };


            return View(model);
        }
    }
}
