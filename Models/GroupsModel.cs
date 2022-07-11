using InsuranceProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models
{
    public class GroupsModel
    {
        public List<SelectCategory> Categories { get; set; }
        public List<SelectCategory> CorporateCategories { get; set; }
        public List<Groups> CorporateCategoriesSSS { get; set; }
        public Groups GroupsInd { get; set; }
        public Groups GroupsCor { get; set; }
        public List<Groups> Groups { get; set; }
        public List<Groups> GroupsCorporate{ get; set; }
        public List<Groups> groupsCategories { get; set; }
        public List<Groups> allCategories { get; set; }
    }
}
