using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel.AdminUsedModels
{
    public class NewCourseViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public CourseType Type { get; set; }
        public CourseStatus Status { get; set; }
    }
}