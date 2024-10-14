using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using System.Linq;

namespace OnlineCoursesApp.BLL.AdminServices
{
    public class AdminComplexService : IAdminComplexService
    {
        private readonly IService<Instructor> _instructorService;
        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;

        public AdminComplexService(IService<Instructor> instructorService, IService<Course> courseService, IService<Student> studentService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _studentService = studentService;
        }

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
        public IQueryable<Instructor> GetAllInstructors()
        {
            return _instructorService.Query();
        }

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
        public IQueryable<Student> GetAllStudents()
        {
            return _studentService.Query();
        }
    }
}
