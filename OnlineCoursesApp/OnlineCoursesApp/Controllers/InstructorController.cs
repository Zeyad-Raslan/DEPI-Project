using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel;
using OnlineCoursesApp.ViewModel.HomePageViewModels;
using OnlineCoursesApp.ViewModel.InstructorViewModels;
using System.Linq;
using System.Security.Claims;
using static OnlineCoursesApp.ViewModel.StudentViewModelForInst;

// NEW 

namespace OnlineCoursesApp.Controllers
{
    [Authorize(Roles = "Instructor")]
    public class InstructorController : Controller
    {
        private readonly IService<Instructor> _instructorService;
        private readonly IService<Course> _courseService;
        private readonly IService<Section> _sectionService;
        private readonly IService<StudentProgress> _studentProgress;
        private readonly SignInManager<IdentityUser> _signInManager;

        public InstructorController(IService<Instructor> instructorService, IService<Course> courseService, IService<Section> sectionService, IService<StudentProgress> studentProgress, SignInManager<IdentityUser> signInManager)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _sectionService = sectionService;
            _studentProgress = studentProgress;
            this._signInManager = signInManager;
        }

        [Authorize(Roles = "Instructor")]

        public async Task<IActionResult> IndexAsync()
        {
            int id;
            string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Instructor currentInstructor = _instructorService.Query()
                .FirstOrDefault(instructor => instructor.IdentityUserID == claimId);

            if (currentInstructor == null || (currentInstructor.AccountStatus != AccountStatus.Active))
            {
                await _signInManager.SignOutAsync();
                return Content("There is no active user with this login");
            }
            id = currentInstructor.InstructorId;

            var instructor = _instructorService.Query()
                                .Include(i => i.Courses)
                                .ThenInclude(i => i.Students)
                                .FirstOrDefault(i => i.InstructorId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            // تمرير InstructorId إلى الـ View باستخدام ViewBag
            ViewBag.InstructorId = instructor.InstructorId;

            var courses = instructor.Courses.Select(course => new CourseHomePageViewModel
            {
                CourseId = course.CourseId,
                CourseName = course.Name,
                NumStudents = course.Students.Count,
                Type = course.Type,
                CourseStatus = course.CourseStatus, // تعيين الحالة الجديدة
                // قراءة الصورة المخزنة من قاعدة البيانات
                 Image = course.Image

            }).ToList();

            return View(courses);
        }





        public IActionResult Profile()
        {
            int id;
            string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Instructor currentInstructor = _instructorService.Query()
                .FirstOrDefault(instructor => instructor.IdentityUserID == claimId);

            if (currentInstructor == null)
            {
                return Content("There is no active user with this login");
            }
            id = currentInstructor.InstructorId;

            var viewModel = new InstructorProfileViewModel
            {
                InstructorId = currentInstructor.InstructorId,
                Name = currentInstructor.Name,
                Email = currentInstructor.Email,
                About = currentInstructor.About,  // Assuming you have an "About" field in Instructor model
                ImageUrl = currentInstructor.Image  // Assuming there's an image URL field
            };
            ViewBag.InstructorId = id;

            return View(viewModel);
        }

        // لعرض بيانات المدرس في صفحة تعديل البيانات
        [HttpGet]
        public IActionResult EditProfile()
        {
            int id;
            string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Instructor currentInstructor = _instructorService.Query()
                .FirstOrDefault(instructor => instructor.IdentityUserID == claimId);

            if (currentInstructor == null)
            {
                return Content("There is no active user with this login");
            }
            id = currentInstructor.InstructorId;
            var viewModel = new EditInstructorProfileViewModel
            {
                InstructorId = currentInstructor.InstructorId,
                Name = currentInstructor.Name,
                About = currentInstructor.About
            };

            return View(viewModel);
        }

        // لحفظ البيانات المعدلة بعد التعديل
        [HttpPost]
        public IActionResult EditProfile(EditInstructorProfileViewModel model)
        {
            int currentInstructorId;
            string claimId = User.Claims.
                FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Instructor currentInstructor = _instructorService.Query()
                .FirstOrDefault(instructor => instructor.IdentityUserID == claimId);

            if (currentInstructor == null)
            {
                return Content("There is no active user with this login");
            }
            currentInstructorId = currentInstructor.InstructorId;

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            // تحديث بيانات المدرس
            currentInstructor.Name = model.Name;
            currentInstructor.About = model.About;

            // حفظ التعديلات في قاعدة البيانات
            _instructorService.Update(currentInstructor);

            return RedirectToAction("Profile", new { id = currentInstructor.InstructorId });
        }

        [HttpPost]
        public IActionResult UpdateProfilePicture(InstructorProfileViewModel model)
        {
            if (model.Image != null && model.Image.Length > 0)
            {
                var instructor = _instructorService.GetById(model.InstructorId);

                if (instructor == null)
                {
                    return NotFound();
                }

                // رفع الصورة وحفظها في مجلد wwwroot/image
                // var fileName = Path.GetFileName(model.Image.FileName);
                string mustFileName = instructor.InstructorId.ToString();
               

                // delete old file if exist

               //// var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Instructor", instructor.InstructorId.ToString());

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Instructor");

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
                var newFfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Instructor", newFileName);
                using (var stream = new FileStream(newFfilePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                // تحديث مسار الصورة في قاعدة البيانات
                instructor.Image = "/image/Instructor/" + newFileName;
                _instructorService.Update(instructor);

                // إعادة توجيه المستخدم إلى صفحة الـ Profile بعد التحديث
                return RedirectToAction("Profile", new { id = model.InstructorId });
            }

            // في حالة عدم وجود صورة جديدة مرفوعة، إعادة عرض الصفحة
            return RedirectToAction("Profile", new { id = model.InstructorId });
        }



        public IActionResult Students(int id)
        {
            //
            int currentInstructorId;
            string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Instructor currentInstructor = _instructorService.Query()
                .FirstOrDefault(instructor => instructor.IdentityUserID == claimId);

            if (currentInstructor == null)
            {
                return Content("There is no active user with this login");
            }
            //
            int courseId = id;

            // الحصول على المحاضر الذي لديه الدورات
            var instructor = _instructorService.Query()
                .Include(i => i.Courses)
                .ThenInclude(c => c.Students) // الحصول على الطلاب مباشرة من الدورة
                .Include(i => i.Courses)
                    .ThenInclude(c => c.Sections) // تضمين الأقسام
                .FirstOrDefault(i => i.Courses.Any(c => c.CourseId == courseId));

            if (instructor == null || 
                instructor.InstructorId != currentInstructor.InstructorId)
            {
                return NotFound();
            }

            var course = instructor.Courses.FirstOrDefault(c => c.CourseId == courseId);

            if (course == null)
            {
                return NotFound();
            }

            // جلب الطلاب المسجلين في الدورة مباشرة
            var students = course.Students.Select(s =>
            {
                // جلب الأقسام الخاصة بالدورة
                var totalSections = course.Sections.Count();

                // جلب عدد الأقسام المكتملة بواسطة الطالب
                var completedSections = _studentProgress.Query()
                    .Where(sp => sp.Student.StudentId == s.StudentId && sp.Course.CourseId == course.CourseId && sp.Status)
                    .Count();

                // حساب التقدم: عدد الأقسام المكتملة / إجمالي عدد الأقسام
                var progress = totalSections > 0 ? (completedSections * 100) / totalSections : 0;

                return new StudentViewModelForInst
                {
                    StudentId = s.StudentId,
                    StudentName = s.Name,
                    Progress = progress // نسبة التقدم
                };
            }).ToList();

            ViewData["CourseName"] = course.Name;
            ViewData["InstructorId"] = instructor.InstructorId;
            return View(students);
        }

        public IActionResult ManageCourse(int id)
        {
            //
            int currentInstructorId;
            string claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Instructor currentInstructor = _instructorService.Query()
                .FirstOrDefault(instructor => instructor.IdentityUserID == claimId);

            if (currentInstructor == null)
            {
                return Content("There is no active user with this login");
            }

            //
            // Retrieve the course and its sections
            var course = _courseService.Query()
                                       .Include(c => c.Sections)
                                       .Include(c => c.Instructor)
                                       .FirstOrDefault(c => c.CourseId == id);
            if(course.Instructor.InstructorId != currentInstructor.InstructorId)
            {
                return Content("You do not have access to this page");
            }
            if (course == null)
            {
                return NotFound();
            }



            var viewModel = new CourseManageViewModel
            {
                CourseId = course.CourseId,
                Title = course.Name,
                Description = course.Description,
                // If the course.Image is null, use a default placeholder image
                Image = course.Image ?? "/images/default-placeholder.png",

                Sections = course.Sections
                               .OrderBy(s => s.Number) // ترتيب الـ Sections حسب رقم Num
                               .Select(s => new SectionViewModel
                               {
                                   CourseId = course.CourseId,
                                   SectionId = s.SectionId,
                                   Title = s.Title,
                                   Link = s.Link,
                                   Number = s.Number
                               })
                               .ToList()
            };
            ViewBag.InstructorId = course.Instructor.InstructorId;
            return View(viewModel);
        }


        [AllowAnonymous]
        public IActionResult ShowInstructorCourses(int instructorId)
        {
            var instructor = _instructorService.Query()
                .Include(inst => inst.Courses)
                .ThenInclude(crs => crs.Students)
                .FirstOrDefault(inst => inst.InstructorId == instructorId);

            if (instructor == null)
            {
                return NotFound(); // التعامل مع حالة عدم وجود المدرس
            }

            var instructorCourses = instructor.Courses
                .Where(crs => crs.CourseStatus == CourseStatus.Approved)
                .ToList();

            List<CoursesHomeViewModel> coursesVM = instructorCourses.Select(crs => new CoursesHomeViewModel()
            {
                CourseId = crs.CourseId,
                CourseName = crs.Name,
                CourseImage = crs.Image,
                CourseDescription = crs.Description,
                NumStudent = crs.Students.Count,
                InstructorName = instructor.Name // إضافة اسم المدرس
            }).ToList();

            return View(coursesVM);
        }




        // ############################################################################################
        // ############################################################################################

        //-------------------------------------- NewCourse
        public IActionResult NewCourse(int id)
        {
            ViewBag.InstructorId = id;
            return View();
        }

        public IActionResult SaveNewCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                string imagePath = null;

                // تحقق إذا كانت الصورة مرفوعة ولها محتوى
                if (model.Image != null && model.Image.Length > 0)
                {
                    // الحصول على اسم الملف من الصورة المرفوعة
                    var fileName = Path.GetFileName(model.Image.FileName);

                    // تحديد مسار حفظ الصورة في wwwroot/image
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

                    // نسخ الملف إلى المجلد المحدد
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Image.CopyTo(stream);
                    }

                    // تحديد المسار الذي سيتم حفظه في قاعدة البيانات (النسبة للمجلد wwwroot)
                    imagePath = "/image/" + fileName;
                }

                // إنشاء الكورس وحفظ المسار في خاصية Image
                var course = new Course
                {
                    Name = model.Name,
                    Type = model.CourseType,
                    Description = model.Description,
                    Image = imagePath,  // مسار الصورة التي تم رفعها
                    CourseStatus = CourseStatus.UnderReview,
                    Instructor = _instructorService.GetById(model.TechId)
                };

                // إضافة الكورس الجديد إلى قاعدة البيانات
                _courseService.Add(course);

                // إعادة توجيه المستخدم لصفحة الـ Index الخاصة بالـ Instructor
                return RedirectToAction("Index", "Instructor", new { id = model.TechId });
            }

            // إعادة عرض الصفحة مع ظهور الأخطاء إن وجدت
            return View("NewCourse", model);
        }


        //------------------------------------------New Section
        [HttpGet]
        [HttpGet]
        public IActionResult NewSection(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewSection(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var section = new Section
                {
                    Title = model.Title,
                    Link = model.Link,
                    Number = model.Number,
                    Course = _courseService.GetById(model.CourseId),
                    SectionId = model.SectionId
                };


                _sectionService.Add(section);

                var course1 = _courseService.Query()
                                       .Include(c => c.Sections)
                                       .FirstOrDefault(c => c.CourseId == model.CourseId);

                var Sections1 = course1.Sections
                     .OrderBy(s => s.Number)
                     .ToList();
                //bool flag = false;
                int x = 1;
                for (var i = 0; i < Sections1.Count; i++)
                {

                    Sections1[i].Number = x;
                    _sectionService.Update(Sections1[i]);
                    x++;

                    //if (flag) break;
                }

                //_sectionService.save();
                //_courseService.save();


                var course = _courseService.Query().Include(s => s.Students).FirstOrDefault(c => c.CourseId == model.CourseId);

                foreach (var std in course.Students)
                {
                    _studentProgress.Add(new StudentProgress()
                    {
                        Course = course,
                        Section = section,
                        Student = std
                    });
                }

                return RedirectToAction("ManageCourse", "Instructor", new { Id = model.CourseId });
            }

            return View("NewSection", model);
        }


        //----------------------------------------------Edit  

        [HttpGet]
        public IActionResult EditSection(int id)
        {
            //var section = _sectionService.GetById(id);
            //var course = _courseService.GetById(id);

            var section = _sectionService.Query().Include(x => x.Course).FirstOrDefault(x => x.SectionId == id);
            if (section == null)
            {
                return NotFound("Section not found.");
            }

            var model = new SectionEditViewModel
            {
                SectionId = section.SectionId,
                Title = section.Title,
                Link = section.Link,
                Number = section.Number,
                CourseId = section.Course.CourseId
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult SaveSectionEdit(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                // _sectionService.Query().Include(x => x.Course).FirstOrDefault(x => x.SectionId == id);
                //var section = _sectionService.GetById(model.SectionId);
                var section = _sectionService.Query().Include(x => x.Course).FirstOrDefault(m => m.SectionId == model.SectionId);

                if (section == null)
                {
                    return NotFound("Section not found.");
                }

                section.Title = model.Title;
                section.Link = model.Link;
                section.Number = model.Number;

                _sectionService.Update(section);

                var course1 = _courseService.Query()
                                       .Include(c => c.Sections)
                                       .FirstOrDefault(c => c.CourseId == model.CourseId);

                var Sections1 = course1.Sections
                     .OrderBy(s => s.Number)
                     .ToList();
                //bool flag = false;
                int x = 1;
                for (var i = 0; i < Sections1.Count; i++)
                {

                    Sections1[i].Number = x;
                    _sectionService.Update(Sections1[i]);
                    x++;

                    //if (flag) break;
                }

                return RedirectToAction("ManageCourse", new { id = model.CourseId });
            }

            return View("EditSection", model);
        }




        ////----------------------------delete 
        public IActionResult DeleteSection(int sectionId)
        {
            //var section = _sectionService.GetById(sectionId);

            var section = _sectionService.Query().Include(x => x.Course).
                                          FirstOrDefault(c => c.SectionId == sectionId);

            var courseID = section.Course.CourseId;

            if (section == null)
            {
                return NotFound("Section not found.");
            }

            _sectionService.Delete(sectionId);

            var course1 = _courseService.Query()
                                   .Include(c => c.Sections)
                                   .FirstOrDefault(c => c.CourseId == courseID);

            var Sections1 = course1.Sections
                 .OrderBy(s => s.Number)
                 .ToList();
            //bool flag = false;
            int x = 1;
            for (var i = 0; i < Sections1.Count; i++)
            {

                Sections1[i].Number = x;
                _sectionService.Update(Sections1[i]);
                x++;

                //if (flag) break;
            }

            return RedirectToAction("ManageCourse", new { id = courseID });
        }

    }
}
