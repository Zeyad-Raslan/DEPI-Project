using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.BLL.StudentService;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel.CourseViewModels;
using OnlineCoursesApp.ViewModel.Student;
using System.Collections.Generic;

namespace project_student.Controllers
{
    public class StudentController : Controller
    {
        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;
        private readonly IStudentComplexService  _studentComplexService;
        public StudentController(IService<Course> courseService, IService<Student> studentService, IStudentComplexService studentComplexService)
        {
             _courseService = courseService;
            _studentService = studentService;
            _studentComplexService = studentComplexService;
        }
        public IActionResult HomePage()
        {
            var  courses = _courseService.Query().
                Include(i=>i.Students).
                Include(i => i.Instructor).ToList();

            List<StudentCoursesHomeViewModel> courceList = courses.Select( e=> new StudentCoursesHomeViewModel()
            {
                CourseId = e.CourseId,
                CourseName = e.Name,
                CourseDescription = e.Description,
                InsrUctorName = e.Instructor.Name,
                NumStudent = e.Students.Count
                
            }).ToList();

            TempData["StudentId"] = 2;
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
        public IActionResult DisplayHomeCourseContent(int courseId)
        {
            Course? course = _courseService.Query()
                .Include(c => c.Sections)
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .Where(c => c.CourseId == courseId)
                .FirstOrDefault();
            CouseContentsViewModel couseContentsViewModel = new CouseContentsViewModel()
            {
               CourseId = course.CourseId,
               Name = course.Name,
               Type = course.Type,
               Description = course.Description,
               Image = course.Image,
               StudentCount = course.Students.Count(),
               InstructoID = course.Instructor.InstructorId,
               InstructorName = course.Instructor.Name,
               Sections = course.Sections

            };
            return View(couseContentsViewModel);
        }
        public IActionResult DisplayMyCourse()
        {
            return View();
        }
        public IActionResult DisplaySession()
        {
            return View();
        }
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
