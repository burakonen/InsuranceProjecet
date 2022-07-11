using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class SelectInsuranceListDetails
    {
        public IEnumerable<SelectGuaranteeName> GuaranteeName { get; set; }
        public IEnumerable<SelectGuarantee> Guarantee { get; set; }
        public IEnumerable<SelectPageDescriptions> PageDescriptions { get; set; }
        public IEnumerable<SelectPageImage> PageImage { get; set; }
        public IEnumerable<SelectMainFaqs> MainFaqs { get; set; }
        public IEnumerable<SelectFaqs> FaqsName { get; set; }
        public IEnumerable<SelectAdvantages> Advantages { get; set; }
    }
}
