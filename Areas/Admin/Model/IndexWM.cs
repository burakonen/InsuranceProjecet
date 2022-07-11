using InsuranceProject.Context;
using InsuranceProject.Models;
using InsuranceProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class IndexWM
    {
        public List<SelectCategory> CategoriesAndInsuranceList { get; set; }
        public PageDescriptionsWM PageDesc { get; set; }
        public List<SelectCategory> CorporatecategoryGroups { get; set; }
        public InsuranceList InsuranceLists { get; set; }
        public Category Category { get; set; }
        public List<Users> InsuranceListUsers { get; set; }
        public MainFaqs MainFaqs { get; set; }
        public SelectCategory IndividualGroup { get; set; }
        public SelectCategory CorporateGroup { get; set; }
        public List<SelectCategory> CategoriesByGroup { get; set; }
        public List<Category> CategoriesInsurunceList { get; set; }
        public SelectCategoryName CategoryName { get; set; }
        public List<GroupsAndUsers> Users { get; set; }
        public int AllCustomerCount { get; set; }
        public List<GroupsAndCategories> IndividiualCount { get; set; }
        public int CorporateCount { get; set; }




    }
}
