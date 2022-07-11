using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Context
{
    public class InsuranceList
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Poliçe adı zorunlu bir alan")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public string SEOURL { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<GuaranteeName> GuaranteeName { get; set; }
        public List<Guarantees> Guarantees { get; set; }
        public List<Advantages> Advantages { get; set; }
        public List<PageImage> PageImages { get; set; }
        public List<PageDescriptions> PageDescriptions { get; set; }
        public List<MainFaqs> MainFaqs { get; set; }
        public List<Faq> Faqs { get; set; }
        public List<RelatedDocuments> RelatedDocuments { get; set; }
        public List<QuickOffer> QuickOffers { get; set; }
        public List<Users> User { get; set; }

    }
}
