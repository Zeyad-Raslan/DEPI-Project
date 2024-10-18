using Humanizer;
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
        private readonly IService<Section> _sectiontService;
        private readonly IService<StudentProgress> _studentProgressService;
        private readonly IStudentComplexService _studentComplexService;
        public StudentController(IService<Course> courseService, IService<Student> studentService,
            IStudentComplexService studentComplexService, IService<StudentProgress> studentProgressService, IService<Section> sectiontService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _studentProgressService = studentProgressService;
            _studentComplexService = studentComplexService;
            _sectiontService = sectiontService;

            // save info to session

        }
        public IActionResult HomePage(int studentId)
        {
            if (studentId == 0)
            {
                if (HttpContext.Session.Keys.Contains("studentId"))
                {
                    studentId = (int)HttpContext.Session.GetInt32("studentId");
                }
                else
                {
                    return Content("Homepage\nStudentId == 0");

                }

            }


            HttpContext.Session.SetInt32("studentId", studentId);
            TempData["studentId"] = studentId;


            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId"); // need authentication 

            var courses = _courseService.Query().
                Include(i => i.Students).
                Include(i => i.Instructor).Where(i => i.CourseStatus == CourseStatus.Approved).ToList();  // filter Home Courses

            Student student = _studentService.GetById(studentId);

            List<StudentCoursesHomeViewModel> courceList = courses.Select(e => new StudentCoursesHomeViewModel()
            {
                CourseId = e.CourseId,
                CourseName = e.Name,
                CourseDescription = e.Description,
                InsrUctorName = e.Instructor.Name,
                NumStudent = e.Students.Count,
                IsEnrolled = (e.Students.Any(st => st.StudentId == studentId))

            }).ToList();

            return View(courceList);
        }
        public IActionResult MyCourses()
        {
            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId"); // need authentication
            //int studentId = Convert.ToInt32(TempData.Peek("studentId"));
            int studentId = (int)HttpContext.Session.GetInt32("studentId");
            TempData["studentId"] = studentId;

            if (studentId == 0)
            {
                return Content("MyCourses\nstudentId == 0");
            }
            var student = _studentService.Query()
                                 .Include(i => i.Courses)
                                 .ThenInclude(c => c.Instructor)
                                 .Where(i => i.StudentId == studentId)
                                 .FirstOrDefault();

            //var currentstudent = student.ToList().First();                        // filter my course
            var courses = student.Courses.Where(i => i.CourseStatus == CourseStatus.Approved || i.CourseStatus == CourseStatus.Closed).
                Select(course => new StudentMyCoursesViewModel()
                {
                    CourseId = course.CourseId,
                    CourseName = course.Name,
                    CourseDescription = course.Description,
                    InsrUctorName = course.Instructor.Name,
                    StudentProgress = _studentComplexService.CountStudentProgress(studentId, course.CourseId)

                }).ToList();

            return View(courses);
        }

        public IActionResult DisplayHomeCourseContent(int courseId)
        {

            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId");

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
        public IActionResult DisplayMyCourseContent(int courseId)
        {
            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId"); // need authentication

            //int studentId = Convert.ToInt32(TempData.Peek("studentId"));
            int studentId = (int)HttpContext.Session.GetInt32("studentId");
            TempData["studentId"] = studentId;
            if (courseId == 0)
            {
                courseId = int.Parse(TempData["courseId"].ToString());
            }

            if (studentId == 0)
            {
                return Content("DisplayMyCourseContent\nstudentId == 0");
            }
            Course? course = _courseService.Query()
                 .Include(c => c.Sections.OrderBy(s => s.Number)) // Order Sections by Number
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .Where(c => c.CourseId == courseId)
                .SingleOrDefault();
            MyCourseContentViewModel myCourseContentsViewModel = new MyCourseContentViewModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Type = course.Type,
                Description = course.Description,
                Image = course.Image,
                StudentCount = course.Students.Count(),
                InstructoID = course.Instructor.InstructorId,
                InstructorName = course.Instructor.Name,
            };

            if (course.Sections.Count() > 0)
                myCourseContentsViewModel.StudentProgress = _studentComplexService.CountStudentProgress(studentId, course.CourseId);
            else myCourseContentsViewModel.StudentProgress = 0;

            foreach (var section in course.Sections)
            {

                var currentSectionStatus = _studentProgressService.Query()
                    .Include(p => p.Student)
                    .Include(p => p.Course)
                    .Include(p => p.Section)
                    .FirstOrDefault(p => p.Course.CourseId == courseId
                             && p.Student.StudentId == studentId
                             && p.Section.SectionId == section.SectionId);
                if (currentSectionStatus == null)
                {
                    continue;
                }

                myCourseContentsViewModel.SectionsStatus.Add(new Pair<Section, bool>()
                {
                    First = section,
                    Second = currentSectionStatus.Status
                });
            }
            return View(myCourseContentsViewModel);
        }
        public IActionResult DisplaySession(int courseId, int sectionId, bool isCompleted)
        {
            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId"); // need authentication
            int studentId = (int)HttpContext.Session.GetInt32("studentId");
            TempData["studentId"] = studentId;

            if (studentId == 0)
            {
                return Content("DisplayMyCourseContent\nstudentId == 0");
            }
            Section section = _sectiontService.GetById(sectionId);

            DisplaySectionViewModel displaySectionViewModel = new DisplaySectionViewModel()
            {
                CourseId = courseId,
                SectionId = sectionId,
                IsCompleted = isCompleted,
                Section = section
            };


            return View(displaySectionViewModel);
        }
        public IActionResult MarkSectionAsCompleted(int courseId, int sectionId)
        {
            int studentId = (int)HttpContext.Session.GetInt32("studentId");
            TempData["studentId"] = studentId;
            var currentProgress = _studentProgressService.Query()
                .Include(p => p.Course)
                .Include(p => p.Section)
                .Include(p => p.Student)
                .Where(p => (
                p.Course.CourseId == courseId
                && p.Section.SectionId == sectionId
                && p.Student.StudentId == studentId
                )).SingleOrDefault();

            if (currentProgress.Status == false)
                currentProgress.Status = true;
            else if (currentProgress.Status == true)
                currentProgress.Status = false;
            _studentProgressService.Update(currentProgress);
            TempData["courseId"] = courseId;
            return RedirectToAction("DisplayMyCourseContent", courseId);
        }

        public IActionResult EnrollCourse(int courseId)
        {
            int studentId = (int)HttpContext.Session.GetInt32("studentId");
            TempData["studentId"] = studentId;
            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId"); // need authentication
            if (studentId == 0)
            {
                return Content("EnrollCourse\nstudentId == 0");
            }
            bool enrollStudent = _studentComplexService.EnrolleStudentInCourse(studentId, courseId);
            if (enrollStudent)
            {
                //return Content("enroll Sucess");
            }
            else
            {
                //return Content("enroll Faild");

            }

            return RedirectToAction("MyCourses", new { studentId = studentId });
        }

        public IActionResult ProfilePage()
        {
            //int studentId = Convert.ToInt32(TempData.Peek("studentId"));
            int studentId = (int)HttpContext.Session.GetInt32("studentId");
            TempData["studentId"] = studentId;

            if (studentId == 0)
            {
                return Content("ProfilePage\nstudentId == 0");
            }

            Student profileInfo = _studentService.GetById(studentId);
            return View(profileInfo);
        }

        [HttpPost]
        public IActionResult SaveProfile(Student model)
        {
            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId"); // need authentication

            var existingStudent = _studentService.GetById(model.StudentId);


            existingStudent.Name = model.Name;
            existingStudent.Education = model.Education;

            _studentService.Update(existingStudent);
            int id = model.StudentId;

            return RedirectToAction("ProfilePage", new { id = model.StudentId });
        }
    }
}
