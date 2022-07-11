using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Areas.Admin.Model
{
    public class CategoryModel
    {
        [Required(ErrorMessage ="Kategori Adı zorunlu bir alan")]
        public string Name { get; set; }
    }
}
