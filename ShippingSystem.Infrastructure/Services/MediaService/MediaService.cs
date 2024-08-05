using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShippingSystem.Application.Abstractions.Interfaces;


namespace ShippingSystem.Infrastructure.Services.MediaService
{
    public class MediaService : IMediaService
    {

        private readonly IWebHostEnvironment _env;

        public MediaService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadFolder = Path.Combine(_env.WebRootPath, folderName);
            Directory.CreateDirectory(uploadFolder); // Ensure the directory exists

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            var newFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadFolder, newFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative path to the file
            return $"https://localhost:44349/{folderName}/{newFileName}";
        }
        public void DeleteImage(string imageUrl)
        {
            var fileName = Path.GetFileName(imageUrl);
            var filePath = Path.Combine(_env.WebRootPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public async Task<string> UpdateImageAsync(string? oldImg,IFormFile file, string folderName)
        {
            if (oldImg is not null)
                DeleteImage(oldImg);
           var img= await UploadImageAsync(file, folderName);
            return img;
        }
    }
}
