using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class PageImageModel
    {
        [Required(ErrorMessage ="Sayfa için resim zorunlu bir alan")]
        public IFormFile PageImage  { get; set; }
    }
}
