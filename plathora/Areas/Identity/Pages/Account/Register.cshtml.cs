using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using plathora.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using plathora.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using plathora.Persistence;
using plathora.Services;

namespace plathora.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAboutUsServices _AboutUsServices;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            
             IAboutUsServices AboutUsServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _AboutUsServices = AboutUsServices;
        }
        

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }



        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [Required]
            [Display(Name = "First Name")]
            public string name { get; set; }


            [Required]
            [Display(Name = "Middle Name")]

            public string MiddleName { get; set; }

            [Required]
            [Display(Name = "Last Name")]

            public string LastName { get; set; }



            [Display(Name = "Mobile No.")]
            public string mobileno1 { get; set; }



 
            public string Role { get; set; }

           public  IEnumerable<SelectListItem> roleList { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            Input = new InputModel()
            {
                 
                roleList = _roleManager.Roles.Where(x => x.Name != SD.Role_Admin).Select(x=>x.Name).Select(i => new SelectListItem
                {
                    Text=i,Value=i
                })
            };
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        //public string generateRandomNo(string name)
        //{
        //    Random generator = new Random();
        //    int r = generator.Next(100000, 1000000);
        //    string uniqueId = name + r;
             
        //    var userList = _db.applicationUsers.Where(x => x.uniqueId == uniqueId).ToList();
        //    if (userList == null || userList.Count == 0)
        //    {
        //        return uniqueId;
        //    }
        //    else
        //    {
        //        generateRandomNo(name);
        //    }

        //    return uniqueId;
        //}
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var loginAdminId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {

                string uniqueNo = _AboutUsServices.generateRandomNo(Input.name.Substring(0, 3));

                //var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var user = new ApplicationUser
                {
                    name = Input.name
                   ,
                    MiddleName=Input.MiddleName,
                    LastName=Input.LastName,
                    UserName = Input.mobileno1
               ,
                    Email = Input.Email               

                    ,
                    PhoneNumber = Input.mobileno1
                    ,
                    Role = Input.Role ,
                    registerbyAffilateID= loginAdminId,
                    uniqueId= uniqueNo

                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
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
                    //await _userManager.AddToRoleAsync(user, SD.Role_Admin);

                   
                    if (user.Role == null)
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_Customer);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, user.Role);
                    }

    




                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        if (user.Role == null)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
