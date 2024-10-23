namespace OnlineCoursesApp.ViewModel.HomePageViewModels
{
    public class CoursesHomeViewModel
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string CourseImage { get; set; }
        public int NumStudent { get; set; }
        public string InstructorName { get; set; } // اسم المدرس
        public string CourseDescription { get; set; }
    }
}