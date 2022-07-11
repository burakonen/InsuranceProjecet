using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class RelatedDocuments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
        public int InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }
        public List<RelatedDocumentsPDF> RelatedDocumentsPDF { get; set; }

    }
}
