using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel.Student;
using System.Collections.Generic;

namespace project_student.Controllers
{
    public class StudentController : Controller
    {
        private readonly IService<Course> _courseService;
        public StudentController(IService<Course> courseService)
        {
             _courseService = courseService;
        }
        public IActionResult HomePage()
        {
            var  courses = _courseService.Query().
                Include(i=>i.Students).
                Include(i => i.Instructor).ToList();

            List<StudentCoursesHomeViewModel> courceList = courses.Select( e=> new StudentCoursesHomeViewModel()
            {
                CourseName = e.Name,
                CourseDescription = e.Description,
                InsrUctorName = e.Instructor.Name,
                NumStudent = e.Students.Count
                
            }).ToList();
            return View("HomePage", courceList);
        }
        public IActionResult MyCourses()
        {
            return View("MyCourses");
        }
        public IActionResult ProfilePage()
        {
            return View();
        }
        public IActionResult DisplayMyCourse()
        {
            return View();
        }
        public IActionResult DisplaySession()
        {
            return View();
        }
        public IActionResult EnrollCourse()
        {
            //add course to my courses list
            return RedirectToAction("MyCourses");
        }


    }
    }
