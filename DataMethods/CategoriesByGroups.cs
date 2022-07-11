using InsuranceProject.DataContext;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.DataMethods
{
    public class CategoriesByGroups
    {

        ApplicationContext context = new ApplicationContext();

        public List<SelectCategory> GetAllCategories()
        {

            var categoryGroups = (from g in context.Groups
                                  join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                                  join c in context.Categories on mcg.CategoryId equals c.Id
                                  where g.Name == "Bireysel"
                                  select new SelectCategory()
                                  {
                                      Name = c.Name,
                                      InsuranceListName = c.InsuranceList.Select(a => new SelectCategoryName() { Name = a.Name })
                                  }).ToList();

            return categoryGroups;
        }




       
    }
}
