using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApp.ViewModel.AdminUsedModels;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.BLL.AdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineCoursesApp.ViewModel.AccountViewModels;
using Microsoft.AspNetCore.Antiforgery;

namespace Admin_Views.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminComplexService _adminService;

        public AdminController(IAdminComplexService adminService)
        {
            _adminService = adminService;
        }

        // Index action
        public IActionResult Index()
        {
            return View();
        }

        // 1. Manage New Courses: Approve or Reject
        public IActionResult ManageNewCourses()
        {
            var newCourses = _adminService.GetNewCourses()
                .Select(course => new NewCourseViewModel
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Type = course.Type,
                    Status = CourseStatus.UnderReview
                }).ToList();

            return View(newCourses);
        }

        [HttpPost]
        public IActionResult ApproveCourse(int courseId)
        {
            _adminService.ApproveCourse(courseId);
            TempData["SuccessMessage"] = "Course approved successfully!";
            return RedirectToAction("ManageNewCourses");
        }

        [HttpPost]
        public IActionResult RejectCourse(int courseId)
        {
            _adminService.RejectCourse(courseId);
            TempData["ErrorMessage"] = "Course rejected!";
            return RedirectToAction("ManageNewCourses");
        }

        // 2. Manage Current Courses: View Details
        public IActionResult ManageCourses()
        {
            var courses = _adminService.GetAllCourses()
                .Include(c => c.Students)
                .Select(course => new ManageCoursesViewModel
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Type = course.Type,
                    StudentCount = course.Students.Count()
                }).ToList();

            return View(courses);
        }

        public IActionResult CourseDetails(int id)
        {
            var course = _adminService.GetCourseById(id);
            if (course == null) return NotFound();

            var viewModel = new CourseDetailsViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Type = course.Type,
                Description = course.Description,
                Students = course.Students.Select(s => new StudentViewModel
                {
                    StudentId = s.StudentId,
                    Name = s.Name
                }).ToList()
            };

            return View(viewModel);
        }


        // 3. Manage Students: View Details and Delete
        public IActionResult ManageStudents()
        {
            var students = _adminService.GetAllStudents()
                .Where(std => std.AccountStatus == AccountStatus.Active)
                .Select(student => new ManageStudentsViewModel
                {
                    StudentId = student.StudentId,
                    Name = student.Name
                }).ToList();

            return View(students);
        }

        public IActionResult StudentDetails(int id)
        {
            var student = _adminService.GetStudentById(id);
            if (student == null) return NotFound();

            var viewModel = new StudentDetailsViewModel
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                Education = student.Education
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            _adminService.DeleteStudent(id);
            TempData["SuccessMessage"] = "Student deleted successfully!";
            return RedirectToAction("ManageStudents");
        }

        // 4. Manage Instructors: View Details and Delete
        public IActionResult ManageInstructors()
        {
            var instructors = _adminService.GetAllInstructors()
                .Select(instructor => new ManageInstructorsViewModel
                {
                    InstructorId = instructor.InstructorId,
                    Name = instructor.Name
                }).ToList();

            return View(instructors);
        }

        public IActionResult InstructorDetails(int id)
        {
            var instructor = _adminService.GetInstructorById(id);
            if (instructor == null) return NotFound();

            var viewModel = new InstructorDetailsViewModel
            {
                InstructorId = instructor.InstructorId,
                Name = instructor.Name,
                Email = instructor.Email,
                About = instructor.About
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteInstructor(int id)
        {
            try
            {
                _adminService.DeleteInstructor(id);
                TempData["SuccessMessage"] = "Instructor deleted successfully!";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("ManageInstructors");
        }

    }
}
