using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class PageDescriptions
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Sayfa başlığı zorunlu bir alan")]
        public string Header { get; set; }


        [Required(ErrorMessage = "Sayfa açıklaması zorunlu bir alan")]
        public string Description { get; set; }


        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
        public int InsuranceListId { get; set; }
        public InsuranceList InsuranceList { get; set; }
    }
}
