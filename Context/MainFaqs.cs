using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class MainFaqs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
        public List<Faq> Faqs { get; set; }

        [ForeignKey("InsuranceListId")]
        public int InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }
    }
}
