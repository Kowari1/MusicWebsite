using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MusicWebSite.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string Name { get; set; }
        public string Role { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        public string Password { get; set; }
        [ValidateNever]
        public string ImageUrl {  get; set; }
    }
}
