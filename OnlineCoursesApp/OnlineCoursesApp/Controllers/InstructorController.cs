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
        private readonly IService<Course> _courseService;
        private readonly IService<Section> _sectionService;
        private readonly IService<StudentProgress> _studentProgress;

        public InstructorController(IService<Instructor> instructorService, IService<Course> courseService, IService<Section> sectionService, IService<StudentProgress> studentProgress)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _sectionService = sectionService;
            _studentProgress = studentProgress;
        }


        public IActionResult Index(int id)
        {
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
                Type = course.Type
            }).ToList();

            return View(courses);
        }

        public IActionResult Profile(int id)
        {
            var instructor = _instructorService.Query().FirstOrDefault(i => i.InstructorId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            var viewModel = new InstructorProfileViewModel
            {
                InstructorId = instructor.InstructorId,
                Name = instructor.Name,
                Email = instructor.Email,
                About = instructor.About,  // Assuming you have an "About" field in Instructor model
                ImageUrl = instructor.Image  // Assuming there's an image URL field
            };

            return View(viewModel);
        }


        public IActionResult Students(int id)
        {
            int courseId = id;

            // الحصول على المحاضر الذي لديه الدورات
            var instructor = _instructorService.Query()
                .Include(i => i.Courses)
                .ThenInclude(c => c.Students) // الحصول على الطلاب مباشرة من الدورة
                .Include(i => i.Courses)
                    .ThenInclude(c => c.Sections) // تضمين الأقسام
                .FirstOrDefault(i => i.Courses.Any(c => c.CourseId == courseId));

            if (instructor == null)
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





        // --------------------------------------------------------------------------------------------------------

        public IActionResult ManageCourse(int id)
        {
            // Retrieve the course and its sections
            var course = _courseService.Query()
                                        .Include(c => c.Sections)
                                        .FirstOrDefault(c => c.CourseId == id);

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
                Sections = course.Sections.Select(s => new SectionViewModel
                {
                    Id = s.SectionId,
                    Title = s.Title,
                    Link = s.Link,
                    Num = s.Number
                }).ToList()
            };


            return View(viewModel);
        }



        [HttpGet]
        public IActionResult EditSection(int id)
        {
            var section = _sectionService.GetById(id);
            if (section == null)
            {
                return NotFound();
            }

            var model = new SectionViewModel
            {
                Id = section.SectionId,
                Title = section.Title,
                Link = section.Link,
                Num = section.Number
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditSection(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var section = _sectionService.GetById(model.Id);
                if (section == null)
                {
                    return NotFound();
                }

                section.Title = model.Title;
                section.Link = model.Link;
                section.Number = model.Num;

                _sectionService.Update(section);
                return RedirectToAction("ManageCourse", new { id = section.Course.CourseId });
            }

            return View(model);
        }

        public IActionResult DeleteSection(int id)
        {
            var section = _sectionService.GetById(id);
            if (section != null)
            {
                _sectionService.Delete(id);
            }

            return RedirectToAction("ManageCourse", new { id = section.Course.CourseId });
        }




        // ----------------------------------------------------------------------------------------------



        // ######################    OMER TASKS #############################################################

        //[HttpGet]
        //public IActionResult NewCourse(int id)
        //{
        //    ViewBag.InstructorId = id;
        //    return View();
        //}


        //public IActionResult SaveNewCourse(CourseViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var course = new Course
        //        {
        //            Name = model.Name,
        //            Type = model.Type,
        //            Description = model.Description,
        //            Image = model.Image,
        //            Status = CourseStatus.UnderReview // Set default status
        //        };

        //        _courseService.Add(course); // Save the course
        //        _courseService.Save();

        //        var tech = new Tech
        //        {
        //            CourseID = course.ID,
        //            InstructorID = model.TechId
        //        };

        //        _techService.Add(tech);
        //        _techService.Save();    

        //        return RedirectToAction("Index");
        //    }

        //    return View("NewCourse", model); // If validation fails, stay on the same page
        //}


        //[HttpPost]
        //public IActionResult SaveNewCourse(CourseViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var course = new Course
        //        {
        //            Name = model.Name,
        //            Type = model.Type,
        //            Description = model.Description,
        //            Image = model.Image,
        //            Status = CourseStatus.UnderReview // Set default status
        //        };

        //        _courseService.Add(course); // Save the course
        //        _courseService.Save(); // تأكد من حفظ الكورس أولاً

        //        // تأكد من أن المعرفات صحيحة قبل إضافة Tech
        //        if (model.TechId > 0) // Assuming TechId is the InstructorId
        //        {
        //            var tech = new Tech
        //            {
        //                CourseID = course.ID, // يجب أن يكون المعرف صحيحًا هنا
        //                InstructorID = model.TechId // تأكد من أن هذا هو المعرف الصحيح
        //            };

        //            _techService.Add(tech); // Save the tech relationship
        //            _techService.Save();
        //        }
        //        else
        //        {
        //            // تعامل مع حالة عدم وجود TechId أو InstructorId بشكل صحيح
        //            ModelState.AddModelError("", "Invalid Instructor ID.");
        //            return View("NewCourse", model);
        //        }

        //        return RedirectToAction("Index");
        //    }

        //    return View("NewCourse", model); // If validation fails, stay on the same page
        //}




        //[HttpGet]
        //public IActionResult NewSection(int courseId)
        //{
        //    var model = new SectionViewModel01 { CourseId = courseId };
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult SaveNewSection(SectionViewModel01 model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var section = new Section
        //        {
        //            Title = model.Title,
        //            Link = model.Link,
        //            Num = model.Num,
        //            CourseID = model.CourseId
        //        };

        //        _sectionService.Add(section);
        //        _sectionService.Save();
        //        return RedirectToAction("ManageCourse", new { id = model.CourseId });
        //    }

        //    return View("NewSection", model);
        //}







    }
}
