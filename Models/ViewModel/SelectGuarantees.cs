using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class SelectGuarantees
    {
        public List<SelectGuarantee> Guarantees { get; set; }
        public List<SelectGuaranteeNameList> GuaranteeNames { get; set; }
    }
}
