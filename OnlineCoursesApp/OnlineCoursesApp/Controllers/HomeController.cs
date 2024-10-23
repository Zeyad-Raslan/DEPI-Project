using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.Models;
using OnlineCoursesApp.ViewModel.HomePageViewModels;
using System.Diagnostics;

namespace OnlineCoursesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<Course> _courseService;

        public HomeController(ILogger<HomeController> logger, IService<Course> courseService)
        {
            _logger = logger;
            this._courseService = courseService;
        }

        public IActionResult Index(string searchQuery, CourseType? selectedType)
        {

            List<Course> courses = _courseService.Query().
                Include(i => i.Students).
                Include(i => i.Instructor).
                Where(i => i.CourseStatus == CourseStatus.Approved).ToList();
                ;

            ViewBag.CourseTypes = new SelectList(Enum.GetValues(typeof(CourseType)), selectedType);

            // If searchQuery is provided, filter the course list
            List<Course> filteredCourses = courses;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                filteredCourses = courses.Where(c => c.Name.ToLower().Contains(searchQuery))
                                .ToList(); // Search by name
            }
            if (selectedType.HasValue)
            {
                filteredCourses = filteredCourses.Where(c => c.Type == selectedType.Value).ToList();
            }
           

            List<CoursesHomeViewModel> courceList = filteredCourses.Select(e => new CoursesHomeViewModel()
            {
                CourseId = e.CourseId,
                CourseName = e.Name,
                CourseImage = e.Image,
                CourseDescription = e.Description,
                InstructorName = e.Instructor.Name,
                NumStudent = e.Students.Count
            }).ToList();

            return View(courceList);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
