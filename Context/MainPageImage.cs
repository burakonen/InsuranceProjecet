using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceProject.Context
{
    public class MainPageImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
