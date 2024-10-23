using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel.AccountViewModels;
using OnlineCoursesApp.ViewModel.AdminUsedModels;
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
                        else if (userVm.Role == "Admin" && userRole == "SuperAdmin")
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

        // Add new Admin
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
       
        public async Task<IActionResult> AddAdmin(NewAdminViewModel newAdminVm)
        {

            if (ModelState.IsValid)
            {
                IdentityUser newAdmin = new IdentityUser();
                newAdmin.Email = newAdminVm.Email;
                newAdmin.UserName = newAdminVm.Email;
                newAdmin.EmailConfirmed = true;
                newAdmin.PasswordHash = newAdminVm.Password;

                // save it
                IdentityResult result = await _userManager.CreateAsync(newAdmin, newAdminVm.Password);

                if (result.Succeeded)
                {
                    // add role 
                    // give it a role 
                    IdentityResult roleResult = new IdentityResult();

                    //
                    roleResult = await _userManager.AddToRoleAsync(newAdmin, "Admin");
                    // add admin to admin table
                    WebAdmin newWebAdmin = new WebAdmin()
                    {
                        Name = newAdminVm.Name,
                        Email = newAdminVm.Email,
                        IdentityUserID = newAdmin.Id,
                        IdentityUser = newAdmin

                    };
                    _webAdminService.Add(newWebAdmin);
                    return Content($"{newWebAdmin.Name} Added Sucessfully as | {"Admin"}");

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
            
        


            
            return View(newAdminVm);
        }
    }
}