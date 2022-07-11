using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class GroupsAndCategories
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int GroupsId { get; set; }
        public Groups Groups { get; set; }
    }
}
