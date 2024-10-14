using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
<<<<<<< HEAD
using System.Linq;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f

namespace OnlineCoursesApp.BLL.AdminServices
{
    public class AdminComplexService : IAdminComplexService
    {
<<<<<<< HEAD
        private readonly IService<Instructor> _instructorService;
        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;

        public AdminComplexService(IService<Instructor> instructorService, IService<Course> courseService, IService<Student> studentService)
        {
            _instructorService = instructorService;
=======
        // all services that needed for admin to do complex service
        private readonly IService<Instructor> _instructorService;
        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;
        public AdminComplexService(OnlineCoursesContext context, IService<Instructor> instructorService, IService<Course> courseService, IService<Student> studentService) 
        {
          _instructorService = instructorService;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
            _courseService = courseService;
            _studentService = studentService;
        }

<<<<<<< HEAD
        // Courses
        public IQueryable<Course> GetAllCourses()
        {
            return _courseService.Query().Where(i => i.CourseStatus != CourseStatus.UnderReview);
        }

        public Course GetCourseById(int courseId)
        {
            return _courseService.Query().FirstOrDefault(c => c.CourseId == courseId);
        }

        public void CreateCourse(Course course)
        {
            _courseService.Add(course); // Adds the course to the database
            _courseService.SaveChanges(); // Save the changes
        }

        public void UpdateCourse(Course course)
        {
            _courseService.Update(course); // Updates the course in the database
            _courseService.SaveChanges();  // Save the changes
        }

        public void DeleteCourse(Course course)
        {
            _courseService.Delete(course); // Deletes the course from the database
            _courseService.SaveChanges();  // Save the changes
        }

        public IQueryable<Course> GetNewCourses()
        {
            return _courseService.Query().Where(i => i.CourseStatus == CourseStatus.UnderReview);
        }

        // Instructors
=======
       

        public IQueryable<Course> GetAllCourses()
        {
            return _courseService.Query().Where(i=> (i.CourseStatus != CourseStatus.UnderReview));
        }

>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
        public IQueryable<Instructor> GetAllInstructors()
        {
            return _instructorService.Query();
        }

<<<<<<< HEAD
        public Instructor GetInstructorById(int instructorId)
        {
            return _instructorService.Query().FirstOrDefault(i => i.InstructorId == instructorId);
        }

        public void CreateInstructor(Instructor instructor)
        {
            _instructorService.Add(instructor);  // Adds the instructor to the database
            _instructorService.SaveChanges();    // Save the changes
        }

        public void UpdateInstructor(Instructor instructor)
        {
            _instructorService.Update(instructor); // Updates the instructor in the database
            _instructorService.SaveChanges();      // Save the changes
        }

        public void DeleteInstructor(Instructor instructor)
        {
            _instructorService.Delete(instructor); // Deletes the instructor from the database
            _instructorService.SaveChanges();      // Save the changes
        }

        // Students
=======
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
        public IQueryable<Student> GetAllStudents()
        {
            return _studentService.Query();
        }
<<<<<<< HEAD
=======

        public IQueryable<Course> GetNewCourses()
        {
            return _courseService.Query().
                Where(i=> i.CourseStatus== CourseStatus.UnderReview);
        }
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
    }
}
