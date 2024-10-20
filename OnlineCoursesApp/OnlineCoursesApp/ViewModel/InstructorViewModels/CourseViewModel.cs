using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp.ViewModel
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public CourseType CourseType { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        // إضافة TechId لربط كورس واحد بتقنية واحدة
        public int TechId { get; set; }
    }

}
