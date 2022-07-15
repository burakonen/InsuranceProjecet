using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class SelectGuarantee
    {
        public int GuaranteeId { get; set; }
        public string Guarantee { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<SelectGuaranteeName> GuaraneeNames { get; set; }
    }
}
