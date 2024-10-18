using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.BLL.AdminServices
{
    public interface IAdminComplexService
    {
        // Manage courses
        IQueryable<Course> GetNewCourses();
        IQueryable<Course> GetAllCourses();
        Course GetCourseById(int id);
        void ApproveCourse(int courseId);
        void RejectCourse(int courseId);

        // Manage students
        IQueryable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int studentId);

        // Manage instructors
        IQueryable<Instructor> GetAllInstructors();
        Instructor GetInstructorById(int id);
        void DeleteInstructor(int instructorId);
    }
}

