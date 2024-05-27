using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MusicWebSite.Models.Validation
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(params string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (Array.IndexOf(_extensions, extension) == -1)
                {
                    string allowedExtensions = string.Join(", ", _extensions);
                    return new ValidationResult($"Allowed file extensions are: {allowedExtensions}.", new[] { validationContext.MemberName });
                }
            }
            else if (value is string url && !string.IsNullOrEmpty(url))
            {
                var extension = Path.GetExtension(url).ToLowerInvariant();
                if (Array.IndexOf(_extensions, extension) == -1)
                {
                    string allowedExtensions = string.Join(", ", _extensions);
                    return new ValidationResult($"Allowed file extensions are: {allowedExtensions}.", new[] { validationContext.MemberName });
                }
            }
            else if (value == null)
            {
                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}
