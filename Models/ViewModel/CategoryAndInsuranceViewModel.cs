using InsuranceProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class CategoryAndInsuranceViewModel
    {
        public List<SelectCategory> Categories { get; set; }
        public List<QuickOffer> QuickOffers { get; set; }
        public List<MainPageImage> MainImage { get; set; }
    }
}
