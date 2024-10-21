using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApp.ViewModel.Test;
using System.Security.Claims;

namespace OnlineCoursesApp.Controllers
{
    public class TestController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public TestController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult ShowUserId()
        {
            string mail = User.Identity.Name;
            Claim claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            return Content($"{mail} : {claimId.Value}");
        }

       public IActionResult EnumCoursType()
        {
            CourseTypeViewModel modle = new CourseTypeViewModel();
            return View(modle);
        }

    }
}
