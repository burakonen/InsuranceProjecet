using InsuranceProject.Context;
using InsuranceProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class GetGuaranteeNamesFromInsuranceListWM
    {
        public List<SelectGuarantees> GuaranteeNames { get; set; }
        public List<InsuranceList> list { get; set; }
        public List<SelectCategoriesAndInsuranceList> categoriesAndInsuranceList { get; set; }
    

    }
}
