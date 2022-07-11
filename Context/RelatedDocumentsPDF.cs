using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class RelatedDocumentsPDF
    {
        public int Id { get; set; }
        public string PDF { get; set; }
        public int RelatedDocumentsId { get; set; }
        public RelatedDocuments RelatedDocuments { get; set; }

    }
}
