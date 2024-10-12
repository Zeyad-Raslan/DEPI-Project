using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.BLL.AdminServices;

using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel.AdminUsedModels;
using Microsoft.EntityFrameworkCore;


namespace Admin_Views.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminComplexService _adminService;

        public AdminController(IAdminComplexService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageNewCourses()
        {
            List<NewCourseViewModel> newCourses = _adminService.GetNewCourses()
                .Select(course => new NewCourseViewModel()
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Type = course.Type
                }).ToList();

            return View(newCourses);
        }
        public IActionResult ManageCourses()
        {
            List<ManageCoursesViewModel> courses = _adminService.GetAllCourses().Include(i => i.Students)
                .Select(course => new ManageCoursesViewModel()
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Type = course.Type,
                    StudentNumber = course.Students.Count()
                }).ToList();

            return View(courses);
        }
        public IActionResult ManageStudents()
        {
            return View();
        }
        public IActionResult ManageInstructors()
        {
            return View();
        }

    }
}
