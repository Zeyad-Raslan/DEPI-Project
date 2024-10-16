namespace OnlineCoursesApp.ViewModel
{
    public class SectionViewModel01
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int Num { get; set; }
        public int CourseId { get; set; } // Foreign key for the Course
    }
}
