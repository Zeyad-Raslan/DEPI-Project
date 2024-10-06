using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel;
using System.Linq;

namespace OnlineCoursesApp.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IService<Instructor> _instructorService;

        public InstructorController(IService<Instructor> instructorService)
        {
            _instructorService = instructorService;
        }

        public IActionResult Index(int id)
        {
            var instructor = _instructorService.Query()
                                               .Include(i => i.Courses)
                                               .ThenInclude(c => c.Enrolls) // إذا كنت بحاجة إلى بيانات الطلاب الملتحقين
                                               .FirstOrDefault(i => i.InstructorId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            var courses = instructor.Courses.Select(course => new CourseViewModelForInst
            {
                CourseId = course.CourseId,
                CourseName = course.Name,
                NumStudents = course.Enrolls.Count,
                Type = course.Type
            }).ToList();

            return View(courses);
        }
    }
}
