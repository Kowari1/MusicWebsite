using Microsoft.AspNetCore.Http;

namespace MusicWEB.Utility
{
    public interface IFileServices
    {
        public string SaveFile(IFormFile? file, string? fileUrl, string folderName);
        public void DeleteFile(string path);
    }
}