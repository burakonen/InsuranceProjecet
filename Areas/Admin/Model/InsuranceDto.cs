namespace InsuranceProjectApp.Areas.Admin.Model
{
    public class InsuranceDto
    {
        public int Id { get; set; }
        public string InsuranceName { get; set; }
        public string InsuranceSeo { get; set; }
        public AdminPageImageDto InsuranceImage { get; set; }
    }
}
