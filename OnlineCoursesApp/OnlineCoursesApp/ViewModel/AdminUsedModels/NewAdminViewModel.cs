using System.ComponentModel.DataAnnotations;

namespace OnlineCoursesApp.ViewModel.AdminUsedModels
{
    public class NewAdminViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
    }
}
