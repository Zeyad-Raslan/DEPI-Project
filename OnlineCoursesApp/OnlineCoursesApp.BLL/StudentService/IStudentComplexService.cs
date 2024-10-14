using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.BLL.StudentService
{
    public interface IStudentComplexService
    {
        bool EnrolleStudentInCourse(int studentId, int courseId);
        int CountStudentProgress(int studentId, int courseId);
        void CompleteSection(int studentId, int courseId, int sectionId);
    }
}
