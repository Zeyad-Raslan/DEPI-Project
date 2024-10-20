using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel
{
    public class CourseHomePageViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int NumStudents { get; set; }
        public CourseType Type { get; set; }
        public CourseStatus CourseStatus { get; set; }  // أضف خاصية CourseStatus
    }
}
