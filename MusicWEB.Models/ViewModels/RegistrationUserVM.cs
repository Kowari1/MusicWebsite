using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MusicWEB.Models.ViewModels
{
    public class RegistrationUserVM
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 10 characters.")]
        public string Name { get; set; }
        [ValidateNever]
        public bool isAdmin { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password length must be between 8 and 20 characters.")]
        public string Password { get; set; }
        [ValidateNever]
        public string PasswordConfirm { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }               
        [ValidateNever]
        public IFormFile? ImageFile { get; set; }
    }
}
