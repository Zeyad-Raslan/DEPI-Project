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

                IdentityResult result = await _userManager.CreateAsync(newUser, newUserVm.Password);
                if (result.Succeeded)
                {
                    // create cookie
                    return Content($"{newUserVm.FirstName} Added Sucessfully");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        if (errorItem.Code == "DuplicateUserName")
                            continue;
                        ModelState.AddModelError("", errorItem.Description);
                    }
                }
            }
            return View(newUserVm);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userModel = await _userManager.FindByEmailAsync(userVm.Email);
                if (userModel != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(userModel, userVm.Password);
                    if (found)
                    {
                        // add cookie
                        await _signInManager.SignInAsync(userModel, userVm.RememberMe);
                        // redirect to appropriate controller
                        // student
                        // instructor
                        if (userVm.Role == "Student")
                        {
                            return Content("Sucess login : student");
                        }
                        else if (userVm.Role == "Instructor")
                        {
                            return Content("Sucess login : Instructor");
                        }
                        
                    }
                }
                ModelState.AddModelError("", "Email or password is wrong");
            }
            return View(userVm);
        }
    }
}
