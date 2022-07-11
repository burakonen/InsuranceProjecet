using InsuranceProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class SelectInsurance
    {
        public string InsuranceName { get; set; }
        public string Url { get; set; }
        public List<SelectPageDescriptions> Description { get; set; }
        public List<SelectPageImage> Image { get; set; }
    }
}
