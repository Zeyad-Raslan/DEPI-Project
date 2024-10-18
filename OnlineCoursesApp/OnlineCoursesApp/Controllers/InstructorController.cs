﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.ViewModel;
using OnlineCoursesApp.ViewModel.InstructorViewModels;
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

        //public IActionResult ManageCourse(int id)
        //{
        //    // Retrieve the course and its sections
        //    var course = _courseService.Query()
        //                                .Include(c => c.Sections)
        //                                .FirstOrDefault(c => c.CourseId == id);

        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    var viewModel = new CourseManageViewModel
        //    {
        //        CourseId = course.CourseId,
        //        Title = course.Name,
        //        Description = course.Description,
        //        // If the course.Image is null, use a default placeholder image
        //        Image = course.Image ?? "/images/default-placeholder.png",
        //        Sections = course.Sections.Select(s => new SectionViewModel
        //        {
        //            Id = s.SectionId,
        //            Title = s.Title,
        //            Link = s.Link,
        //            Num = s.Number
        //        }).ToList()
        //    };


        //    return View(viewModel);
        //}

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
               
                Sections = course.Sections
                                 .OrderBy(s => s.Number) // ترتيب الـ Sections حسب رقم Num
                                 .Select(s => new SectionViewModel
                                 {
                                     CourseId  = course.CourseId,
                                     SectionId = s.SectionId,
                                     Title = s.Title,
                                     Link = s.Link,
                                     Number = s.Number
                                 })
                                 .ToList()
            };

            return View(viewModel);
        }


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
                var course = new Course
                {
                    Name = model.Name,
                    Type = model.Type,
                    Description = model.Description,
                    Image = model.Image,
                    CourseStatus = CourseStatus.UnderReview,   
                    Instructor = _instructorService.GetById(model.TechId) 
                };

                _courseService.Add(course);

                return RedirectToAction("Index", "Instructor", new { id = model.TechId }); 
            }

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
              var course =  _courseService.Query().Include(s => s.Students).FirstOrDefault(c=>c.CourseId == model.CourseId);
                
                foreach (var std in course.Students) {

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
                var section = _sectionService.Query().Include(x=>x.Course).FirstOrDefault(m=> m.SectionId == model.SectionId);

                if (section == null)
                {
                    return NotFound("Section not found.");
                }

                section.Title = model.Title;
                section.Link = model.Link;
                section.Number = model.Number;

                _sectionService.Update(section); 

                return RedirectToAction("ManageCourse", new { id = model.CourseId });
            }

            return View("EditSection", model);
        }




        ////----------------------------delete 
        public IActionResult DeleteSection(int sectionId)
        {
            //var section = _sectionService.GetById(sectionId);

            var section = _sectionService.Query().Include(x => x.Course).
                                          FirstOrDefault(c=>c.SectionId==sectionId);

            var courseID = section.Course.CourseId;

            if (section == null)
            {
                return NotFound("Section not found.");
            }

            _sectionService.Delete(sectionId);

            return RedirectToAction("ManageCourse", new { id = courseID });
        }






    }
}
