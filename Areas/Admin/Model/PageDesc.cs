using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class PageDesc
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Sayfa Başlığı zorunlu bir alan")]
        public string Header { get; set; }



        [Required(ErrorMessage = "Sayfa açıklamasıı zorunlu bir alan")]
        public string Description { get; set; }

        public string InsuranceName { get; set; }
    }
}
