using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel.CourseViewModels
{
    public class DisplaySectionViewModel
    {
        public Section Section {  get; set; }
        public bool IsCompleted{  get; set; }
        public int CourseId{  get; set; }
        public int SectionId{  get; set; }
    }
}
