using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class GuaranteeName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public string GuaranteeDescription { get; set; }



        [ForeignKey("InsuranceListId")]
        public int InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }


        [ForeignKey("GuaranteesId")]
        public int? GuaranteesId { get; set; }
        public Guarantees Guarantees { get; set; }
    }
}
