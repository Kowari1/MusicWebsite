using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MusicWebSite.Utility.Validation;
using MusicWebSite.Models.Validation;

namespace MusicWebSite.Models
{
    public class Music
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the title")]
        public string Title { get; set; }
        [RequiredCategoryId(ErrorMessage = "Please select a category")]
        public int GenreId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [ValidateNever]
        public string MusicUrl { get; set; }
    }
}
