using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel.CourseViewModels
{
    public class CouseContentsViewModel
    {
        public int CourseId { get; set; }

        public string Name { get; set; } = null!;

        public CourseType Type { get; set; }

        public string Description { get; set; } = null!;


        public string? Image { get; set; }

        public int StudentCount {  get; set; }
        public virtual ICollection<Section> Sections { get; set; }

        public Instructor Instructor { get; set; }
        public string InstructorName { get; set; }
        public int InstructoID { get; set; }
    }
}
