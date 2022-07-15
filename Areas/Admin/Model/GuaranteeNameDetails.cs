using InsuranceProject.Context;
using InsuranceProjectApp.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class GuaranteeNameDetails
    {
        public ICollection<SelectInsuranceGuarantee> Guarantees { get; set; }

        [Required(ErrorMessage = "Teminat ismi zorunlu bir alan")]
        public string Name { get; set; }
        public string Descriptions { get; set; }
    }
}
