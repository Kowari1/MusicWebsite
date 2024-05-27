using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace MusicWEB.Utility
{
    public class FileServices : IFileServices
    {
        public FileServices() { }

        private readonly IWebHostEnvironment webHostEnvironment;

        public FileServices(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public string SaveFile(IFormFile? file, string? fileUrl, string folderName)
        {
            if (file != null)
            {
                if (fileUrl != null)
                {
                    DeleteFile(Path.Combine(webHostEnvironment.WebRootPath, fileUrl.TrimStart('/')));
                    return SaveFile(file, folderName);
                }
                else
                {
                    return SaveFile(file, folderName);
                }
            }
            return fileUrl;
        }

        private string SaveFile(IFormFile file, string folder)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "files", folder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Path.Combine("/files", folder, uniqueFileName);
        }
    }
}
