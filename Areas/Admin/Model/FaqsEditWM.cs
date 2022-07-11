using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class FaqsEditWM
    {


        [Required(ErrorMessage = "Soru zorunlu bir alan")]
        public string Question { get; set; }



        [Required(ErrorMessage = "Cevap zorunlu bir alan")]
        public string Answer { get; set; }
    }
}
