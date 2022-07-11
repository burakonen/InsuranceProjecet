using InsuranceProject.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.DataContext
{
    public class ApplicationContext:IdentityDbContext<Users>
    {
      
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5EJQMOF;Database=InsuranceApp;Uid=bö;Pwd=123456;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<GroupsAndCategories>()
                .HasKey(c => new { c.CategoryId, c.GroupsId });

            builder.Entity<GroupsAndUsers>()
                .HasKey(c => new { c.UsersId, c.GroupsId });

        }



        public DbSet<Groups> Groups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Advantages> Advantages { get; set; }
        public DbSet<InsuranceList> InsuranceLists { get; set; }
        public DbSet<GuaranteeName> GuaranteeNames { get; set; }
        public DbSet<Guarantees> Guarantees { get; set; }
        public DbSet<PageImage> PageImages { get; set; }
        public DbSet<PageDescriptions> PageDescriptions { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<MainFaqs> MainFaqs { get; set; }
        public DbSet<MapCategoryGroup> MapCategoryGroups { get; set; }
        public DbSet<UserInsuranceList> UserInsuranceLists { get; set; }
        public DbSet<RelatedDocuments> RelatedDocuments { get; set; }
        public DbSet<RelatedDocumentsPDF> RelatedDocumentsPDFs { get; set; }
        public DbSet<QuickOffer> QuickOffers { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<MainPageImage> MainPageImages { get; set; }
        public DbSet<GroupsAndCategories> GroupsAndCategories { get; set; }
        public DbSet<GroupsAndUsers> GroupsAndUsers { get; set; }





    }
}
