using System.ComponentModel.DataAnnotations;

namespace OnlineCoursesApp.ViewModel.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
        public bool RememberMe { get; set; }
    }
}
