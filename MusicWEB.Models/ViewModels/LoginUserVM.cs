
using System.ComponentModel.DataAnnotations;

namespace MusicWEB.Models.ViewModels
{
    public class LoginUserVM
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password length must be between 8 and 20 characters.")]
        public string Password { get; set; }
    }
}
