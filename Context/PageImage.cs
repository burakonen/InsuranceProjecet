using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class PageImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PageHeader { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public int InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }
    }
}


