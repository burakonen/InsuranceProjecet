using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class MainFaqsWM
    {
        public string mainfaqs { get; set; }
        public int InsuranceListId { get; set; }


        [Required(ErrorMessage = "Sık sorulanlar için başlık zorunlu bir alan")]
        public string Name { get; set; }


    }
}
