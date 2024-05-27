using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MusicWebSite.Models.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        public string? PasswordConfirm { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
