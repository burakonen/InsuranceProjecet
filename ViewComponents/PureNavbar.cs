using InsuranceProject.DataContext;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.ViewComponents
{
    public class PureNavbar : ViewComponent
    {
        ApplicationContext context = new ApplicationContext();

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCategory = RouteData?.Values["id"];
            ViewBag.GroupId = RouteData?.Values["GroupId"];

            var bireysel = context.Groups.Where(i => i.Name == "BİREYSEL").Include(s => s.GroupsAndCategories).ThenInclude(a => a.Category).ThenInclude(s => s.InsuranceList).ToList();
            var kurumsal = context.Groups.Where(i => i.Name == "KURUMSAL").Include(s => s.GroupsAndCategories).ThenInclude(a => a.Category).ThenInclude(s => s.InsuranceList).ToList();



            var model = new GroupsModel()
            {
                Groups = bireysel,
                GroupsCorporate = kurumsal

            };


            return View(model);
        }
    }
}
