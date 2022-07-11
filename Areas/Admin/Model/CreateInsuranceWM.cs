using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class CreateInsuranceWM
    {
        [Required(ErrorMessage ="Poliçe adı zorunlu bir alan")]
        public string InsuranceName { get; set; }

        [Required(ErrorMessage = "Sayfa başlığı zorunlu bir alan")]
        public string PageHeader { get; set; }

        [Required(ErrorMessage = "Sayfa açıklması adı zorunlu bir alan")]
        public string PageDesc { get; set; }

        [Required(ErrorMessage = "Sayfa resmi zorunlu bir alan")]
        [DataType(DataType.Upload)]
        public IFormFile PageImage { get; set; }
    }
}
