using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
<<<<<<< HEAD
=======
using OnlineCoursesApp.BLL.StudentService;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel.Student;
using System.Collections.Generic;

namespace project_student.Controllers
{
    public class StudentController : Controller
    {
        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;
<<<<<<< HEAD
        public StudentController(IService<Course> courseService, IService<Student> studentService)
        {
             _courseService = courseService;
            _studentService = studentService;
=======
        private readonly IStudentComplexService  _studentComplexService;
        public StudentController(IService<Course> courseService, IService<Student> studentService, IStudentComplexService studentComplexService)
        {
             _courseService = courseService;
            _studentService = studentService;
            _studentComplexService = studentComplexService;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
        }
        public IActionResult HomePage()
        {
            var  courses = _courseService.Query().
                Include(i=>i.Students).
                Include(i => i.Instructor).ToList();

            List<StudentCoursesHomeViewModel> courceList = courses.Select( e=> new StudentCoursesHomeViewModel()
            {
<<<<<<< HEAD
=======
                CourseId = e.CourseId,
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
                CourseName = e.Name,
                CourseDescription = e.Description,
                InsrUctorName = e.Instructor.Name,
                NumStudent = e.Students.Count
                
            }).ToList();
<<<<<<< HEAD
=======

            TempData["StudentId"] = 2;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
            return View(courceList);
        }
        public IActionResult MyCourses(int studentId)
        {
            
            var student = _studentService.Query()
                                 .Include(i => i.Courses)
                                 .ThenInclude(c=> c.Instructor)
                                 .Where(i => i.StudentId == studentId)
                                 .FirstOrDefault();

            //var currentstudent = student.ToList().First();
            var  courses = student.Courses.
                Select(course=> new StudentMyCoursesViewModel()
            {
                CourseName=course.Name,
                CourseDescription = course.Description,
                InsrUctorName = course.Instructor.Name
            }).ToList();

            return View(courses);
        }
        public IActionResult ProfilePage(int id)
        {
            Student profileInfo = _studentService.GetById(id);
            return View(profileInfo);
        }
<<<<<<< HEAD
=======
        public IActionResult DisplayHomeCourses()
        {
            return View();
        }
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
        public IActionResult DisplayMyCourse()
        {
            return View();
        }
        public IActionResult DisplaySession()
        {
            return View();
        }
<<<<<<< HEAD
        public IActionResult EnrollCourse()
        {
            //add course to my courses list
=======
        public IActionResult EnrollCourse(int studentId, int courseId)
        {

            bool enrollStudent = _studentComplexService.EnrolleStudentInCourse(studentId, courseId);
            if(enrollStudent)
            {
                return Content("enroll Sucess");
            }
            else
            {
                return Content("enroll Faild");

            }

>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
            return RedirectToAction("MyCourses");
        }

        [HttpPost]
        public IActionResult SaveProfile(Student model)
        {
            var existingStudent = _studentService.GetById(model.StudentId);


            existingStudent.Name = model.Name;
            existingStudent.Education = model.Education;

            _studentService.Update(existingStudent);
            int id = model.StudentId;

            return RedirectToAction("ProfilePage", new { id = model.StudentId });
        }
    }
    }
