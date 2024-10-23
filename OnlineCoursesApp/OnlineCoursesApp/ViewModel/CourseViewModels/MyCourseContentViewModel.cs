using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel.CourseViewModels
{
    public class MyCourseContentViewModel
    {
        public MyCourseContentViewModel()
        {
            SectionsStatus = new List<Pair<Section, bool>>();
        }
        public int CourseId { get; set; }

        public string Name { get; set; } = null!;

        public CourseType Type { get; set; }

        public string Description { get; set; } = null!;


        public string? Image { get; set; }

        public int StudentCount { get; set; }
        public int StudentProgress { get; set; }
        public List<Pair<Section,bool>> SectionsStatus { get; set; }

        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
        public string InstructorImage { get; set; }
        public string InstructorAbout {  get; set; }

       
    }
}

