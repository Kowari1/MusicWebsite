using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MusicWEB.Models
{
    public class User
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
        public string ImageUrl { get; set; }
        [ValidateNever]
        public ICollection<UserMusic> UserMusic { get; set; }
    }
}
