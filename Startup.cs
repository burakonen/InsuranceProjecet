using InsuranceProject.Areas.Admin.Model;
using InsuranceProject.Context;
using InsuranceProject.DataContext;
using InsuranceProject.DataMethods;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Routing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;


namespace InsuranceProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<CategoriesByGroups>();
            services.AddScoped<GetGroupName>();
            services.AddScoped<GetAllCategories>();
            services.AddDbContext<ApplicationContext>();
            services.AddScoped<GetAllUser>();

            //services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(
                   CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(i => {
                       i.LoginPath = "/Account/Login";
                       i.LogoutPath = "/Account/Logout";
                   }
           );

        }

     

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                  Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img")),
                RequestPath = new PathString("/MyImages")
            });


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints =>
            {



                endpoints.MapControllerRoute(
                 name: "admin",
                 pattern: "{area:exists}/{name}/ExportToExcell",
                 defaults: new { controller = "Admin", action = "ExportToExcell" });

                //endpoints.MapControllerRoute(
                //  name: "admin",
                //  pattern: "{area:exists}/{name}/CategoryDetails",
                //  defaults: new { controller = "Category", action = "CategoryDetails" });

                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "{area:exists}/admin/MainFaqsDetails/{id}",
                   defaults: new { controller = "Admin", action = "MainFaqsDetails" });

                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/admin/{name}/CreateInsurance",
                    defaults: new { controller = "Admin", action = "CreateInsurance" });

                endpoints.MapControllerRoute(
                     name: "MyArea",
                     pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "InstitutionalInsuranceForm",
                  pattern: "/kurumsal/teklif-al/{url}",
                  defaults: new { controller = "Institutional", action = "InsuranceForm" });

                
                
                endpoints.MapControllerRoute(
                  name: "HomeInsuranceForm",
                  pattern: "/bireysel/teklif-al/{url}",
                  defaults: new { controller = "Home", action = "InsuranceForm" });

                endpoints.MapControllerRoute(
                  name: "PolicyPageInstitutional",
                  pattern: "/kurumsal/policeler/{url}",
                  defaults: new { controller = "Institutional", action = "PolicyPages" });

                endpoints.MapControllerRoute(
                  name: "PolicyPages",
                  pattern: "/bireysel/policeler/{url}",
                  defaults: new { controller = "Home", action = "PolicyPages" });


                //endpoints.MapControllerRoute(
                //    name: "searchResult",
                //    pattern: "arama/{query}",
                //    defaults: new { controller = "Home", action = "arama" });

                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "arama",
                    defaults: new { controller = "Home", action = "Search" });


                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}",
                   defaults: new { controller = "Home", action = "Index" }

               );


            });
        }
    }
}
