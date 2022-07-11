using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class Advantages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public int SigortaListeleriId { get; set; }
        public InsuranceList SigortaListeleri { get; set; }
    }
}
