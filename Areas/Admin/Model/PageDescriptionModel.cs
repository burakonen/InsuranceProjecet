using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class PageDescriptionModel
    {
        [Required(ErrorMessage = "Sayfa Başlığı zorunlu bir alan")]
        public PageDescriptionsWM PageDesc { get; set; }
    }
}
