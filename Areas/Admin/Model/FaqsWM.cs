using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class FaqsWM
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int InsuranceListId { get; set; }
        public int MainFaqsId { get; set; }
    }
}
