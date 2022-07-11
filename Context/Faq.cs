using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class Faq
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public int? InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }
        public int MainFaqsId { get; set; }
        public MainFaqs MainFaqs { get; set; }
    }
}
