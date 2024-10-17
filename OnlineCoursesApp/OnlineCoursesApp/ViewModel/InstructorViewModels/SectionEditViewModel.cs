namespace OnlineCoursesApp.ViewModel.InstructorViewModels
{
    public class SectionEditViewModel
    {
        public int SectionId { get; set; }   
        public string Title { get; set; } = null!;   
        public string Link { get; set; } = null!;   
        public int Number { get; set; }   
        public int CourseId { get; set; }   
    }

}
