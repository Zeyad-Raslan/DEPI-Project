using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel.AdminUsedModels
{
    public class ManageCoursesViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public CourseType Type { get; set; }
        public int StudentCount { get; set; }
    }
}

