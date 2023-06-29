using System.ComponentModel.DataAnnotations;

namespace Authentication.Application.ViewModels
{
    public class UserRegistration
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Document number is required")]
        public string? DocumentNumber { get; set; }
    }
}
