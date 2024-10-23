using System.ComponentModel.DataAnnotations;

namespace OnlineCoursesApp.ViewModel.InstructorViewModels
{
    public class EditInstructorProfileViewModel
    {
        public int InstructorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? About { get; set; }
    }

}
