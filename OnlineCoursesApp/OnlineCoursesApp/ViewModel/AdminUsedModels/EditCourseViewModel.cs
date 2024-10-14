using System;

namespace OnlineCoursesApp.ViewModel.AdminUsedModels
{
    public class EditCourseViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
    }
}
