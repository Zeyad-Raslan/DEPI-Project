using OnlineCoursesApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.BLL.AdminServices
{
    public interface IAdminService
    {
        IQueryable<Course> GetNewCourses();
        IQueryable<Course> GetAllCourses();
        IQueryable<Instructor> GetAllInstructors();
        IQueryable<Student> GetAllStudents();

    }
}
