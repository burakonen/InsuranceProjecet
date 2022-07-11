using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class QuickOffer
    {
        public int Id { get; set; }
        public int InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }
        public string İcon { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
