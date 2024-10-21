using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel.AdminUsedModels
{
    public class CourseDetailsViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public CourseType Type { get; set; }
        public string Description { get; set; }

        public List<StudentViewModel> Students { get; set; }
    }

    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
}
