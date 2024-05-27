
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicWebSite.Models.Validation;

namespace MusicWebSite.Models.ViewModels
{
    public class MusicVM
    {
        public Music Music {  get; set; }
        public IEnumerable<SelectListItem> CategoryList;

        [ValidateNever]
        public string? ErrorMessageForImage { get; set; }
        [ValidateNever]
        public string? ErrorMessageForAudio { get; set; }
    }
}
