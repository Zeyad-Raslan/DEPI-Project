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
    public interface IAdminComplexService
    {
<<<<<<< HEAD
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
=======
        IQueryable<Course> GetNewCourses();
        IQueryable<Course> GetAllCourses();
        IQueryable<Instructor> GetAllInstructors();
        IQueryable<Student> GetAllStudents();

>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
    }
}
