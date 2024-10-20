namespace OnlineCoursesApp.ViewModel
{
    public class InstructorProfileViewModel
    {
     

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? About { get; set; }
      
        public IFormFile? Image { get; set; }  // لرفع صورة جديدة
        public string? ImageUrl { get; set; }  // لعرض صورة حالية
    }
}
