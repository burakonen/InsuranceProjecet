using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class Category
    {
        public int Id { get; set; }
        

        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public List<InsuranceList> InsuranceList { get; set; }
        public List<GroupsAndCategories> GroupsAndCategories { get; set; }

    }
}
