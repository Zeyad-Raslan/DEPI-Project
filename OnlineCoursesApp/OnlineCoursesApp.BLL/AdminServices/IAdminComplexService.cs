using OnlineCoursesApp.DAL.Models;
using System.Linq;

namespace OnlineCoursesApp.BLL.AdminServices
{
    public interface IAdminComplexService
    {
        // Courses
        IQueryable<Course> GetNewCourses();
        IQueryable<Course> GetAllCourses();
        Course GetCourseById(int courseId); // Get a specific course by ID
        void CreateCourse(Course course);   // Create a new course
        void UpdateCourse(Course course);   // Update an existing course
        void DeleteCourse(Course course);   // Delete a course

        // Instructors
        IQueryable<Instructor> GetAllInstructors();
        Instructor GetInstructorById(int instructorId); // Get a specific instructor by ID
        void CreateInstructor(Instructor instructor);   // Create a new instructor
        void UpdateInstructor(Instructor instructor);   // Update an existing instructor
        void DeleteInstructor(Instructor instructor);   // Delete an instructor

        // Students
        IQueryable<Student> GetAllStudents();
    }
}
