using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OnlineCoursesApp.ViewModel.AccountViewModels;

namespace OnlineCoursesApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newUserVm)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser();
                newUser.Email = newUserVm.Email;
                newUser.UserName = newUserVm.Email;
                newUser.EmailConfirmed = true;
                newUser.PasswordHash = newUserVm.Password;

                IdentityResult result =  await _userManager.CreateAsync(newUser, newUserVm.Password);
                if (result.Succeeded)
                {
                    // create cookie
                    return Content($"{newUserVm.FirstName} Added Sucessfully");
                }
                else
                {
                    foreach(var errorItem in result.Errors)
                    {
                        if (errorItem.Code == "DuplicateUserName")
                            continue;
                        ModelState.AddModelError("", errorItem.Description);
                    }
                }
            }
            return View(newUserVm);
        }
    }
}
