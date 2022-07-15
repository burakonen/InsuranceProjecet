using InsuranceProject.Models.ViewModel;
using InsuranceProjectApp.Models.ViewModel;
using System.Collections.Generic;

namespace InsuranceProjectApp.Areas.Admin.Model
{
    public class SelectInsuranceGuarantee
    {
        public int Id { get; set; }
        public List<SelectGuarantee> GuaranteeName { get; set; }
        public string InsuranceName { get; set; }
        public List<SelectGroupName> GroupsName { get; set; }
        public string CategoryName { get; set; }
        public string Guaraantee { get; set; }
        public bool Date { get; set; }
    }
}
