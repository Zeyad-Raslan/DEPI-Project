namespace OnlineCoursesApp.ViewModel.Student
{
    public class StudentCoursesHomeViewModel
    {
        public int CourseId { get; set; } 
        public string? CourseName { get; set; }
        public string? CourseImage { get; set; }
        public int NumStudent { get; set; }
        public bool IsEnrolled { get; set; }

        //public string Type { get; set; } //will be enum letter
        public string InsrUctorName {  get; set; }
        public string CourseDescription {  get; set; }
    }
}
