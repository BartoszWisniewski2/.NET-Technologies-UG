using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

using CoffeProject.Models;
using CoffeProject.Utility;

namespace CoffeProject.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel, IValidatableObject
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "To pole jest wymagane :)")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "To pole jest wymagane :)")]
            [StringLength(100, ErrorMessage = "{0} musi miec co najmniej {2} a maksymalnie {1} znaków.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdź hasło")]
            [Compare("Password", ErrorMessage = "Hasła się nie zgadzają")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "To pole jest wymagane :)")]
            [Display(Name = "Imię")]
            public string Name { get; set; }


            [Required(ErrorMessage = "To pole jest wymagane :)")]
            [Display(Name = "Numer telefonu")]
            public string PhoneNumber { get; set; }


            [Display(Name = "Miasto")]
            public string City { get; set; }

            [Display(Name = "Województwo")]
            public string State { get; set; }

            [Display(Name = "Kod Pocztowy")]
            public string PostalCode { get; set; }

            [Display(Name = "Ulica")]
            public string StreetAddress { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string role = Request.Form["rdUserRole"].ToString();


            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Name = Input.Name,
                    City = Input.City,
                    StreetAddress = Input.StreetAddress,
                    State = Input.State,
                    PostalCode = Input.PostalCode,
                    PhoneNumber = Input.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if(await _roleManager.RoleExistsAsync(SD.AdminUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminUser));
                    }
                    if (await _roleManager.RoleExistsAsync(SD.ModeratorUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.ModeratorUser));
                    }
                    if (await _roleManager.RoleExistsAsync(SD.CustomerUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.CustomerUser));
                    }
             
                    if (role == SD.ModeratorUser)
                    {
                        await _userManager.AddToRoleAsync(user, SD.ModeratorUser);
                    }
                    else
                    {
                        if (role == SD.AdminUser)
                        {
                            await _userManager.AddToRoleAsync(user, SD.AdminUser);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, SD.CustomerUser);
                           // await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }

                    return RedirectToAction("Index", "User", new { area = "Admin" });

                    //_logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");



                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
