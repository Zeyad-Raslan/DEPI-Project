using System.ComponentModel.DataAnnotations;

namespace OnlineCoursesApp.ViewModel.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]

        public string FirstName {  get; set; }

        [Required]
        [DataType(DataType.Text)]

        public string LastName { get; set; }

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

        [DataType(DataType.Text)]
        public string? Education { get; set; }

        [Required]
        public string Role { get; set; }



    }
    
}
