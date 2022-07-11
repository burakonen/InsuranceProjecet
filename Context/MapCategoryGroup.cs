using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class MapCategoryGroup
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int GroupId { get; set; }
    }
}
