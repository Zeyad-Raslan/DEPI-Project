using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel;
using System.Linq;
using static OnlineCoursesApp.ViewModel.StudentViewModelForInst;

namespace OnlineCoursesApp.Controllers
{

    public class InstructorController : Controller
    {


        private readonly IService<Instructor> _instructorService;
        private readonly IService<Tech> _techService;
        private readonly IService<Course> _courseService;

        public InstructorController(IService<Instructor> instructorService, IService<Tech> techService, IService<Course> courseService)
        {
            _instructorService = instructorService;
            _techService = techService;
            _courseService = courseService;
        }




  
        public IActionResult Index(int id)
        {
            var instructor = _instructorService.Query()
                                               .Include(i => i.Techs)
                                               .ThenInclude(t => t.Course)
                                               .ThenInclude(c => c.Enrollments) 
                                               .FirstOrDefault(i => i.ID == id);

            if (instructor == null)
            {
                return NotFound(); 
            }

            ViewBag.InstructorId = instructor.ID;

            var courses = instructor.Techs.Select(t => new CourseViewModelForInst
            {
                CourseId = t.Course.ID,
                CourseName = t.Course.Name,
                NumStudents = t.Course.Enrollments.Count(), 
                Type = t.Course.Type,
                Status = t.Course.Status 
            }).ToList();

            return View(courses); 
        }

        public IActionResult Students(int id)
        {
            var course = _courseService.Query()
                                       .Include(c => c.Enrollments) 
                                       .ThenInclude(e => e.Student) 
                                       .Include(c => c.StudentProgresses) 
                                       .FirstOrDefault(c => c.ID == id);

            if (course == null)
            {
                return NotFound();
            }

          
            var students = course.Enrollments.Select(e => new StudentViewModelForInst
            {
                StudentId = e.Student.ID,
                StudentName = e.Student.Name, 
                Progress = course.StudentProgresses
                                 .Where(sp => sp.StudentID == e.Student.ID)
                                 .Select(sp => sp.IsCompleted ? 100 : 0) 
                                 .FirstOrDefault() 
            }).ToList();

            ViewData["CourseName"] = course.Name;
            ViewData["InstructorId"] = course.Techs.FirstOrDefault()?.InstructorID;

            return View(students); 
        }

        public IActionResult Profile(int id)
        {
            var instructor = _instructorService.Query().FirstOrDefault(i => i.ID == id);

            if (instructor == null)
            {
                return NotFound();
            }

            var viewModel = new InstructorProfileViewModel
            {
                InstructorId = instructor.ID,
                Name = instructor.Name,
                Email = instructor.Email,
                About = instructor.About,  
                ImageUrl = instructor.Image  
            };

            return View(viewModel);
        }




        // Task Omer (Action, View, if you need ModelView )
        public IActionResult NewCourse()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult AddSection()
        {
            return View();
        }

        public IActionResult EditSection()
        {
            return View();
        }




    }
}
