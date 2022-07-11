using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Models.ViewModel
{
    public class UserWM
    {

        [Required(ErrorMessage ="Zorunlu bir alan")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Zorunlu bir alan")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Zorunlu bir alan")]
        public string TCKN { get; set; }

        [Required(ErrorMessage = "Zorunlu bir alan")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Zorunlu bir alan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu bir alan")]
        public string PhoneNumber { get; set; }
    }
}
