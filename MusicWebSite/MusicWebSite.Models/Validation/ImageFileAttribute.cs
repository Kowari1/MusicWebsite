
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MusicWebSite.Utility.Validation
{
    public class ImageFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                if (!file.ContentType.StartsWith("image"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
