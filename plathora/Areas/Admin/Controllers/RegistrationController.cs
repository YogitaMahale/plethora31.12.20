using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Services;
using plathora.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = SD.Role_Admin)]
    public class RegistrationController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegistrationController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
               // returnUrl = returnUrl ?? Url.Content("~/");
                //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                if (ModelState.IsValid)
                {
                    //var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                    var user = new ApplicationUser
                    {
                        name = model.name
                       ,
                        UserName = model.mobileno1
                   ,
                        Email = model.Email

                        ,
                        PhoneNumber = model.mobileno1
                        ,
                        Role = SD.Role_Customer

                    };
                    var result = await _userManager.CreateAsync(user, "Password@1");
                    if (result.Succeeded)
                    {
                        //_logger.LogInformation("User created a new account with password.");
                        if (!await _roleManager.RoleExistsAsync(SD.Role_Admin))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                        }

                        if (!await _roleManager.RoleExistsAsync(SD.Role_Affilate))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Affilate));
                        }
                        if (!await _roleManager.RoleExistsAsync(SD.Role_Customer))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
                        }
                        // await _userManager.AddToRoleAsync(user, SD.Role_Admin);
                        if (user.Role == null)
                        {
                            await _userManager.AddToRoleAsync(user, SD.Role_Customer);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, user.Role);
                        }
                       
                        //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        //{
                        //    return RedirectToPage("RegisterConfirmation", new { email = model.name, returnUrl = returnUrl });
                        //}
                        //else
                        //{
                            //await _signInManager.SignInAsync(user, isPersistent: false);
                            if (user.Role == null)
                            {
                                await _signInManager.SignInAsync(user, isPersistent: false);
                            return RedirectToAction("Index", "Home", new { Area = "Admin" });
                        }
                            else
                            {
                            var result1 = await _signInManager.PasswordSignInAsync(model.mobileno1, "Password@1", false, lockoutOnFailure: false);

                            return RedirectToAction("Index", "Home", new { Area = "Admin" });
                            }

                        //}
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return View();
                // If we got this far, something failed, redisplay form

            }
            else
            {
                return View();
            }

        }
    }

}
