using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.BLL.StudentService;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel;
using OnlineCoursesApp.ViewModel.CourseViewModels;
using OnlineCoursesApp.ViewModel.Student;
using OnlineCoursesApp.ViewModel.StudentViewModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace project_student.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;
        private readonly IService<Section> _sectiontService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IService<StudentProgress> _studentProgressService;
        private readonly IStudentComplexService _studentComplexService;
        public StudentController(IService<Course> courseService, IService<Student> studentService,
            IStudentComplexService studentComplexService, IService<StudentProgress> studentProgressService, IService<Section> sectiontService, SignInManager<IdentityUser> signInManager)
        {
            _courseService = courseService;
            _studentService = studentService;
            _studentProgressService = studentProgressService;
            _studentComplexService = studentComplexService;
            _sectiontService = sectiontService;
            this._signInManager = signInManager;

            // save info to session

        }

        public IActionResult HomePage(string searchQuery, CourseType? selectedType)
        {
            int studentId;
                string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            Student currentStd = _studentService.Query()
                .FirstOrDefault(std => std.IdentityUserID == claimId);

            if(currentStd == null)
            {
                return Content("There is no active user with this logins");
            }
            studentId = currentStd.StudentId;


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

            ViewBag.CourseTypes = new SelectList(Enum.GetValues(typeof(CourseType)), selectedType);
            List<Course> filteredCourses = courses;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                filteredCourses = courses.Where(c => c.Name.ToLower().Contains(searchQuery))
                                .ToList(); // Search by name
            }
            if (selectedType.HasValue)
            {
                filteredCourses = filteredCourses.Where(c => c.Type == selectedType.Value).ToList(); // serach by type
            }
            List<StudentCoursesHomeViewModel> courceList = filteredCourses.Select(e => new StudentCoursesHomeViewModel()
            {
                CourseId = e.CourseId,
                CourseName = e.Name,
                CourseImage = e.Image,
                CourseDescription = e.Description,
                InsrUctorName = e.Instructor.Name,
                NumStudent = e.Students.Count,
                IsEnrolled = (e.Students.Any(st => st.StudentId == studentId))

            }).ToList();

            return View(courceList);
        }
        public async Task<IActionResult> MyCoursesAsync()
        {
            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId"); // need authentication
            //int studentId = Convert.ToInt32(TempData.Peek("studentId"));
            //
            int studentId;
            string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Student currentStudent = _studentService.Query()
                .FirstOrDefault(student => student.IdentityUserID == claimId);

            if (currentStudent == null || (currentStudent.AccountStatus != AccountStatus.Active))
            {
                await _signInManager.SignOutAsync();
                return Content("There is no active user with this login");
            }
            studentId = currentStudent.StudentId;
            TempData["studentId"] = studentId;


            //
         
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

        [AllowAnonymous]
        public IActionResult DisplayHomeCourseContent(int courseId)
        {

            //TempData["studentId"] = HttpContext.Session.GetInt32("studentId");

            Course? course = _courseService.Query()
                .Include(c => c.Sections)
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .Where(c => (c.CourseId == courseId) && (c.CourseStatus == CourseStatus.Approved))
                .FirstOrDefault();
            CouseContentsViewModel couseContentsViewModel = new CouseContentsViewModel()
            {
                CourseId = course.CourseId,
                Image = course.Image,
                Name = course.Name,
                Type = course.Type,
                Description = course.Description,
                StudentCount = course.Students.Count(),
                Instructor = course.Instructor,
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
                InstructorID = course.Instructor.InstructorId,
                InstructorName = course.Instructor.Name,
                InstructorImage = course.Instructor.Image,
                InstructorAbout = course.Instructor.About
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

        public async Task<IActionResult> ProfilePageAsync()
        {
            //
            int studentId;
            string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Student currentStudent= _studentService.Query()
                .FirstOrDefault(student => student.IdentityUserID == claimId);

            if (currentStudent == null || (currentStudent.AccountStatus != AccountStatus.Active))
            {
                await _signInManager.SignOutAsync();
                return Content("There is no active user with this login");
            }
            studentId = currentStudent.StudentId;
            TempData["studentId"] = studentId;


            //
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
        [HttpPost]
        public IActionResult UpdateProfilePicture(StudentProfileViewModel model)
        {
            if (model.Image != null && model.Image.Length > 0)
            {
                var student = _studentService.GetById(model.StudentId);

                if (student == null)
                {
                    return NotFound();
                }

                // رفع الصورة وحفظها في مجلد wwwroot/image
                // var fileName = Path.GetFileName(model.Image.FileName);
                string mustFileName = student.StudentId.ToString();


                // delete old file if exist

                //// var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Student", Student.StudentId.ToString());

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Student");

                var files = Directory.GetFiles(folderPath)
                             .Where(f => Path.GetFileNameWithoutExtension(f).Equals(mustFileName, System.StringComparison.OrdinalIgnoreCase))
                             .ToList();

                foreach (var oldFile in files)
                {
                    if (System.IO.File.Exists(oldFile))
                    {
                        // Delete the file
                        System.IO.File.Delete(oldFile);
                    }
                }


                // update by new file 
                string fileExtension = Path.GetExtension(model.Image.FileName);
                var newFileName = mustFileName + fileExtension;
                var newFfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Student", newFileName);
                using (var stream = new FileStream(newFfilePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                // تحديث مسار الصورة في قاعدة البيانات
                student.Image = "/image/Student/" + newFileName;
                _studentService.Update(student);

                // إعادة توجيه المستخدم إلى صفحة الـ Profile بعد التحديث
                return RedirectToAction("ProfilePage", new { id = model.StudentId });
            }

            // في حالة عدم وجود صورة جديدة مرفوعة، إعادة عرض الصفحة
            return RedirectToAction("ProfilePage", new { id = model.StudentId });
        }

    }
}
