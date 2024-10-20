namespace OnlineCoursesApp.ViewModel
{
    public class CourseManageViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        // حقل لرفع الصورة
        public IFormFile ImageFile { get; set; }

        public List<SectionViewModel> Sections { get; set; } = new List<SectionViewModel>();
    }

}
