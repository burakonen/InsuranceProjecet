using InsuranceProject.DataContext;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.DataMethods
{
    public class GetAllCategories
    {
       
        
        ApplicationContext context = new ApplicationContext();
      
        public List<SelectCategory> GetCategories()
        {
            var individualcategoryGroups = (from g in context.Groups
                                            join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                                            join c in context.Categories on mcg.CategoryId equals c.Id
                                            where g.Name == "Bireysel"
                                            select new SelectCategory()
                                            {
                                                CategoryId = c.Id,
                                                Name = c.Name,
                                                GroupName = g.Name,
                                                GroupId = g.Id,
                                                InsuranceListName = c.InsuranceList.Select(a => new SelectCategoryName() { Name = a.Name, Url = a.SEOURL})
                                            }).ToList();

            return individualcategoryGroups;

        }

        public List<SelectCategory> GetCorporateCategorie()
        {
            var CorporatecategoryGroups = (from g in context.Groups
                                           join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                                           join c in context.Categories on mcg.CategoryId equals c.Id
                                           where g.Name == "Kurumsal"
                                           select new SelectCategory()
                                           {
                                               Name = c.Name,
                                               GroupName = g.Name,
                                               InsuranceListName = c.InsuranceList.Select(a => new SelectCategoryName() { Name = a.Name, Url = a.SEOURL })
                                           }).ToList();

            return CorporatecategoryGroups;
        }



    }
}
