namespace OnlineCoursesApp.ViewModel.AdminUsedModels
{
    public class ManageStudentsViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }

    public class StudentDetailsViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
    }
}
