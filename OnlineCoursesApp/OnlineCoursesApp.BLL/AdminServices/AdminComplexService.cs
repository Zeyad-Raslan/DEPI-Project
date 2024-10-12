using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.BLL.AdminServices
{
    public class AdminComplexService : IAdminComplexService
    {
        private readonly IService<Instructor> _instructorService;
        private readonly IService<Course> _courseService;
        private readonly IService<Student> _studentService;
        public AdminComplexService(OnlineCoursesContext context, IService<Instructor> instructorService, IService<Course> courseService, IService<Student> studentService) 
        {
          _instructorService = instructorService;
            _courseService = courseService;
            _studentService = studentService;
        }

       

        public IQueryable<Course> GetAllCourses()
        {
            return _courseService.Query().Where(i=> (i.CourseStatus != CourseStatus.UnderReview));
        }

        public IQueryable<Instructor> GetAllInstructors()
        {
            return _instructorService.Query();
        }

        public IQueryable<Student> GetAllStudents()
        {
            return _studentService.Query();
        }

        public IQueryable<Course> GetNewCourses()
        {
            return _courseService.Query().
                Where(i=> i.CourseStatus== CourseStatus.UnderReview);
        }
    }
}
