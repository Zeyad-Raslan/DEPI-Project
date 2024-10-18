using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace OnlineCoursesApp.BLL.StudentService
{
    public class StudentComplexService : IStudentComplexService
    {

        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;
        private readonly IService<StudentProgress> _studentProgressService;


        public StudentComplexService(IService<Course> courseService, IService<Student> studentService, IService<StudentProgress> studentProgressService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _studentProgressService = studentProgressService;
        }

        public bool EnrolleStudentInCourse(int studentId, int courseId)
        {
            // get student
            var student = _studentService.Query()
                                 .Include(i => i.Courses)
                                 .Where(i => i.StudentId == studentId)
                                 .FirstOrDefault();

            // get course
            var course = _courseService.Query()
                                 .Include(i => i.Sections)
                                 .Include(i=> i.Students)
                                 .Where(i => i.CourseId == courseId)
                                 .FirstOrDefault();

            if (course.Students.Any(st => st.StudentId == studentId))
            {
                return false;
            } 
            // add course in student
            student.Courses.Add(course);
            // update student
            _studentService.Update(student);
            // add student in course
            course.Students.Add(student);
            // update course
            _courseService.Update(course);

            // update progress
            var sections = course.Sections;
            foreach (var section in sections)
            {
                _studentProgressService.Add(new StudentProgress()
                {
                   Section = section,
                   Course = course,
                   Student = student
                    
                });
            }

            return true;
        }
        public int CountStudentProgress(int studentId, int courseId) 
        {
            //get sections
            var countCompletesection = _studentProgressService.Query()
                                 .Include(i => i.Student)
                                 .Include(i => i.Course)
                                 .Where(i => i.Student.StudentId == studentId 
                                          && i.Course.CourseId == courseId
                                          && i.Status == true).Count();

            var countSection = _courseService.Query()
                                 .Include(i => i.Sections)
                                 .FirstOrDefault(crs => crs.CourseId == courseId)
                                 .Sections.Count();

            int percentProgress = (int)(((float)countCompletesection / (float)countSection) * 100);

            return (percentProgress > 0) ? percentProgress : 0;

        }
        public void CompleteSection(int studentId, int courseId, int sectionId)
        {
            //get sections
            var sectionStatus = _studentProgressService.Query()
                                 .Include(i => i.Status)
                                 .Include(i => i.Student)
                                 .Include(i => i.Course)
                                 .Include(i => i.Section)   
                                 .Where(i => i.Student.StudentId == studentId
                                          && i.Course.CourseId == courseId
                                          && i.Section.SectionId == sectionId).SingleOrDefault();
            //sectionStatus.Student.StudentId = studentId;
            //sectionStatus.Course.CourseId = courseId;
            //sectionStatus.Section.SectionId = sectionId;
            //sectionStatus.Status = (sectionStatus.Status == false) ? true : false ; 

            if (sectionStatus.Status == false) sectionStatus.Status = true;
            else if(sectionStatus.Status == true) sectionStatus.Status = false;

            _studentProgressService.Update(sectionStatus);

        }


    }
}
