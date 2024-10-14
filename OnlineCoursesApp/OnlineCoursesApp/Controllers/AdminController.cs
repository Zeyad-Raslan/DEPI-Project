using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.BLL.AdminServices;

using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel.AdminUsedModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Admin_Views.Controllers
{
    public class AdminController : Controller
    {
        // Need to use admin complex service here
        private readonly IAdminComplexService _adminService;

        public AdminController(IAdminComplexService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Existing method for managing new courses
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

        // Existing method for managing courses
        public IActionResult ManageCourses()
        {
            List<ManageCoursesViewModel> courses = _adminService.GetAllCourses()
                .Include(i => i.Students)
                .Select(course => new ManageCoursesViewModel()
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Type = course.Type,
                    StudentNumber = course.Students.Count()
                }).ToList();

            return View(courses);
        }

        // New method: Create a course
        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View(); // Return a view to fill in course details
        }

        [HttpPost]
        public IActionResult CreateCourse(CreateCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Name = model.Name,
                    Type = model.Type,
                    StartDate = model.StartDate,
                    // Add other course fields as necessary
                };
                _adminService.CreateCourse(course); // Assuming the service has this method
                return RedirectToAction("ManageCourses");
            }
            return View(model);
        }

        // New method: Edit an existing course
        [HttpGet]
        public IActionResult EditCourse(int courseId)
        {
            var course = _adminService.GetCourseById(courseId);
            if (course == null)
            {
                return NotFound();
            }

            var viewModel = new EditCourseViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Type = course.Type,
                StartDate = course.StartDate
                // Add other necessary fields
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditCourse(EditCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = _adminService.GetCourseById(model.CourseId);
                if (course == null)
                {
                    return NotFound();
                }

                // Update course fields
                course.Name = model.Name;
                course.Type = model.Type;
                course.StartDate = model.StartDate;
                // Add other fields

                _adminService.UpdateCourse(course); // Assuming the service has this method
                return RedirectToAction("ManageCourses");
            }
            return View(model);
        }

        // New method: Delete a course
        [HttpPost]
        public IActionResult DeleteCourse(int courseId)
        {
            var course = _adminService.GetCourseById(courseId);
            if (course == null)
            {
                return NotFound();
            }

            _adminService.DeleteCourse(course); // Assuming the service has this method
            return RedirectToAction("ManageCourses");
        }

        public IActionResult ManageStudents()
        {
            return View();
        }

        public IActionResult ManageInstructors()
        {
            return View();
        }
        public IActionResult ManageInstructors()
        {
            List<ManageInstructorsViewModel> instructors = _adminService.GetAllInstructors()
                .Select(instructor => new ManageInstructorsViewModel()
                {
                    InstructorId = instructor.InstructorId,
                    Name = instructor.Name,
                    Specialty = instructor.Specialty,
                    CourseCount = instructor.Courses.Count() // Example if instructors are linked to courses
                }).ToList();

            return View(instructors);
        }

        [HttpGet]
        public IActionResult CreateInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInstructor(CreateInstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var instructor = new Instructor
                {
                    Name = model.Name,
                    Specialty = model.Specialty,
                };
                _adminService.CreateInstructor(instructor);
                return RedirectToAction("ManageInstructors");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditInstructor(int instructorId)
        {
            var instructor = _adminService.GetInstructorById(instructorId);
            if (instructor == null)
            {
                return NotFound();
            }

            var viewModel = new EditInstructorViewModel
            {
                InstructorId = instructor.InstructorId,
                Name = instructor.Name,
                Specialty = instructor.Specialty
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditInstructor(EditInstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var instructor = _adminService.GetInstructorById(model.InstructorId);
                if (instructor == null)
                {
                    return NotFound();
                }

                instructor.Name = model.Name;
                instructor.Specialty = model.Specialty;

                _adminService.UpdateInstructor(instructor);
                return RedirectToAction("ManageInstructors");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteInstructor(int instructorId)
        {
            var instructor = _adminService.GetInstructorById(instructorId);
            if (instructor == null)
            {
                return NotFound();
            }

            _adminService.DeleteInstructor(instructor);
            return RedirectToAction("ManageInstructors");
        }

        public IActionResult DetailsInstructor(int instructorId)
        {
            var instructor = _adminService.GetInstructorById(instructorId);
            if (instructor == null)
            {
                return NotFound();
            }

            var viewModel = new InstructorDetailsViewModel
            {
                InstructorId = instructor.InstructorId,
                Name = instructor.Name,
                Specialty = instructor.Specialty,
                Courses = instructor.Courses.Select(c => new CourseViewModel
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    Type = c.Type
                }).ToList()
            };

            return View(viewModel);
        }

        // -----------------------------------------
        // STUDENTS MANAGEMENT (NEW)
        // -----------------------------------------

        public IActionResult ManageStudents()
        {
            List<ManageStudentsViewModel> students = _adminService.GetAllStudents()
                .Select(student => new ManageStudentsViewModel
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    EnrollmentDate = student.EnrollmentDate
                }).ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult DetailsStudent(int studentId)
        {
            var student = _adminService.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound();
            }

            var viewModel = new StudentDetailsViewModel
            {
                StudentId = student.StudentId,
                Name = student.Name,
                EnrollmentDate = student.EnrollmentDate
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            var student = _adminService.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound();
            }

            _adminService.DeleteStudent(student);
            return RedirectToAction("ManageStudents");
        }
    }
}
