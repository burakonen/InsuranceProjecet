using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class GuaranteeNameWM
    {
        public int insuranceListId { get; set; }


        [Required(ErrorMessage = "Teminat ismi zorunlu bir alan")]
        public int GuaranteeId { get; set; }

        [Required(ErrorMessage = "Teminat detayı zorunlu bir alan")]
        public string GuaranteeName { get; set; }
        public string GuaranteeDesc { get; set; }
    }
}
