using InsuranceProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class InsuranceListDetailsWM
    {
        public List<SelectInsuranceListDetails> InsuranceListDetails { get; set; }
        public List<SelectCategory> CategoriesByGroups { get; set; }
        public SelectSeoUrl Url { get; set; }
        public SelectAdvantagesCount AdvantagesCount { get; set; }
    }
}
