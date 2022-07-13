using InsuranceProject.DataContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsuranceProject.Area.Admin.Controllers
{


    [AllowAnonymous]
    public class AccountController : Controller
    {

        ApplicationContext context = new ApplicationContext();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
            
        }


        [HttpPost]
        public async Task<IActionResult> Login(InsuranceProject.Context.Admin model)
        {
            var admin = context.Admin.Where(i => i.Email == model.Email && i.PasswordHash == model.PasswordHash).FirstOrDefault();

            if(admin != null)
            {
                var claim = new List<Claim>
                {

                    new Claim(ClaimTypes.Email, model.Email)

                };

                var claimIdentity = new ClaimsIdentity(claim, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Admin", new { Area = "Admin" });
            }
            else
            {
                return View(model);
            }
            
        }



        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }







    }
}
