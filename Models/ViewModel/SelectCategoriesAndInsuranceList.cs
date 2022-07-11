using InsuranceProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class SelectCategoriesAndInsuranceList
    {
        public string Name { get; set; }
        public List<SelectViewModel> InsuranceList { get; set; }
    }
}
