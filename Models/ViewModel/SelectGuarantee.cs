using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class SelectGuarantee
    {
        public string Guarantee { get; set; }
        public IEnumerable<SelectGuaranteeName> GuaraneeNames { get; set; }
    }
}
