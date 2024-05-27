
using System.ComponentModel.DataAnnotations;

namespace MusicWebSite.Models.Validation
{
    public class RequiredCategoryIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var music = (Music)validationContext.ObjectInstance;

            if (music.GenreId == 0)
            {
                return new ValidationResult(ErrorMessage ?? "Please select a category.");
            }

            return ValidationResult.Success;
        }
    }
}
