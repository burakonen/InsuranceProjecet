using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class PageDescriptionsWM
    {
        [Required(ErrorMessage = "Sayfa Başlığı zorunlu bir alan")]
        public PageDesc PageDescWM { get; set; }
    
    
    
    }
}
