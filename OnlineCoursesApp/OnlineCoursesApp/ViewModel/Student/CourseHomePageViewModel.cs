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
<<<<<<< HEAD
        //public int CourseId { get; set; } 
=======
        public int CourseId { get; set; } 
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
        public string? CourseName { get; set; }
        public int NumStudent { get; set; }
        
        //public string Type { get; set; } //will be enum letter
        public string InsrUctorName {  get; set; }
        public string CourseDescription {  get; set; }
    }
}
