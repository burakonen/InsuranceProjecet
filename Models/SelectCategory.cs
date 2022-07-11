using InsuranceProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models
{
    public class SelectCategory
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string GroupName { get; set; }
        public DateTime CategoryDate { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<SelectCategoryName> InsuranceListName { get; set; }
    }
}
