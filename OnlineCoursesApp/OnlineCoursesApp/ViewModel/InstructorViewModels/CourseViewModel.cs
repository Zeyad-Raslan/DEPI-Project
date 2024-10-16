namespace OnlineCoursesApp.ViewModel
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        // إضافة TechId لربط كورس واحد بتقنية واحدة
        public int TechId { get; set; }
    }

}
