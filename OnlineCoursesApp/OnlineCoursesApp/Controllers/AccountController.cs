using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel.AccountViewModels;
using System.Security.Claims;

namespace OnlineCoursesApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IService<Student> _studentService;
        private readonly IService<Instructor> _instructorService;
        private readonly IService<WebAdmin> _webAdminService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IService<Student>_studentService, IService<Instructor> instructorService, IService<WebAdmin> webAdminService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._studentService = _studentService;
            this._instructorService = instructorService;
            this._webAdminService = webAdminService;
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



                // save it
                IdentityResult result = await _userManager.CreateAsync(newUser, newUserVm.Password);
                if (result.Succeeded)
                {
                    // add role 
                    // give it a role 
                    IdentityResult roleResult = new IdentityResult();
                    if (newUserVm.Role == "Student")
                    {
                        roleResult = await _userManager.AddToRoleAsync(newUser, newUserVm.Role);
                        // add student to the student table
                        Student newStudent = new Student()
                        {
                            Name = newUserVm.FirstName + " " + newUserVm.LastName,
                            Email = newUserVm.Email,
                            Education = newUserVm.Education,
                            IdentityUserID = newUser.Id,
                            IdentityUser = newUser
                            
                        };
                        _studentService.Add(newStudent);
                        return RedirectToAction("Login");

                    }
                    else if (newUserVm.Role == "Instructor")
                    {
                        roleResult = await _userManager.AddToRoleAsync(newUser, newUserVm.Role);
                        // add instructor to instructor table
                        Instructor newInstructoer = new Instructor()
                        {
                            Name = newUserVm.FirstName + " " + newUserVm.LastName,
                            Email = newUserVm.Email,
                            About = newUserVm.Education,
                            IdentityUserID = newUser.Id,
                            IdentityUser = newUser

                        };
                        _instructorService.Add(newInstructoer);
                        return RedirectToAction("Login");


                    }
                    //else if (newUserVm.Role == "Admin")
                    //{
                    //    roleResult = await _userManager.AddToRoleAsync(newUser, newUserVm.Role);
                    //    // add admin to admin table
                    //    WebAdmin newWebAdmin = new WebAdmin()
                    //    {
                    //        Name = newUserVm.FirstName + " " + newUserVm.LastName,
                    //        Email = newUserVm.Email,
                    //        IdentityUserID = newUser.Id,
                    //        IdentityUser = newUser

                    //    };
                   //     _webAdminService.Add(newWebAdmin);
                  //      return Content($"{newUserVm.FirstName} Added Sucessfully as | {newUserVm.Role}");

                  //  }
                  //  // create cookie
                  
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
                        // get the user real role
                        var userRole = User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.Role).Value;
                        // redirect to appropriate controller
                        // student
                        // instructor
                        if (userVm.Role == "Student" && userRole == "Student")
                        {
                            return RedirectToAction("HomePage", "Student");
                        }
                        else if (userVm.Role == "Instructor" && userRole == "Instructor")
                        {
                            return RedirectToAction("index", "Instructor");
                        }
                        else if (userVm.Role == "Admin" && userRole == "Admin")
                        {
                            return RedirectToAction("index", "Admin");
                        }

                    }
                }
                ModelState.AddModelError("", "Email or password is wrong");
            }
            return View(userVm);
        }

        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddNewRole()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewRole(NewRoleViewModel roleVm)

        {
            if (roleVm != null)
            {
                IdentityRole newRole = new IdentityRole();
                newRole.Name = roleVm.RoleName.Trim();
                await _roleManager.CreateAsync(newRole);
                return Content($"{roleVm} added");
            }
            //await _roleManager.CreateAsync(newRole);
            return Content($"failed to add role a{roleVm}");

        }
    }
}