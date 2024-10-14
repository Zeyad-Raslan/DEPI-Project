namespace OnlineCoursesApp.ViewModel.Student
{
    public enum CourseType 
    {
        BackEnd,
        FrontEnd,
        CyberSecurity,
        UI_UX,
        DataBase
    }
    public class StudentCoursesHomeViewModel
    {
        //public int CourseId { get; set; } 
        public string? CourseName { get; set; }
        public int NumStudent { get; set; }
        
        //public string Type { get; set; } //will be enum letter
        public string InsrUctorName {  get; set; }
        public string CourseDescription {  get; set; }
    }
}
