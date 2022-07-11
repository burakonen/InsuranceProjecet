using InsuranceProject.DataContext;
using InsuranceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.DataMethods
{
    public class GetGroupName
    {
        ApplicationContext context = new ApplicationContext();

        public SelectCategory GetIndividiaulGroupName()
        {
            var GroupName = (from g in context.Groups
                             join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                             join c in context.Categories on mcg.CategoryId equals c.Id
                             where g.Name == "Bireysel"
                             select new SelectCategory()
                             {

                                 GroupName = g.Name,

                             }).FirstOrDefault();
            return GroupName;
        }





        public SelectCategory GetCorporateGroupName()
        {
            var CorporateGroupName = (from g in context.Groups
                                     join mcg in context.MapCategoryGroups on g.Id equals mcg.GroupId
                                     join c in context.Categories on mcg.CategoryId equals c.Id
                                     where g.Name == "Kurumsal"
                                     select new SelectCategory()
                                     {

                                         GroupName = g.Name,

                                     }).FirstOrDefault();
                    return CorporateGroupName;
        }







    }
}
