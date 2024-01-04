using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Service.ImagesService
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebHostEnvironment _host;
        private readonly StringBuilder _defaultPath;

        public PhotoService(IWebHostEnvironment host,IHttpContextAccessor contextAccessor)
        {
            _host = host;
            _defaultPath = new StringBuilder(@$"{contextAccessor.HttpContext?.Request.Scheme}://{contextAccessor?.HttpContext?.Request.Host}/FOLDER/");

        }

        public async Task<bool> RemoveImageAsync(string url)
        {
            if (url == null) return false;
            string RootPath = _host.WebRootPath.Replace("\\\\", "\\");
            var mediaNameToDelete = Path.GetFileNameWithoutExtension(url);
            var EXT = Path.GetExtension(url);
            string? oldPath = "";
           oldPath = $@"{RootPath}\ClientImages\{mediaNameToDelete}{EXT}";

            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
                return true;
            }
            return false;
        }

        public async Task<string> UpdateImageAsync(string oldUrl, IFormFile newMedia)
        {
            string imageResult = "";
            if(oldUrl is not null) 
             await RemoveImageAsync(oldUrl);
            if (newMedia is not null)
               imageResult=await UploadImageAsync(newMedia);
            return  imageResult;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
               if (image.Length <= 0)
                throw new BadRequestException("file null");
               string RootPath = _host.WebRootPath;
            string fileName = Guid.NewGuid().ToString();
            var extention = Path.GetExtension(image.FileName);
            StringBuilder mainPath = _defaultPath;
            string path = "";
            var mediaPath = Path.Combine(RootPath, "ClientImages");
            path += mainPath.Replace("FOLDER", "ClientImages");


            //  var uploads = Path.Combine(Directory.GetCurrentDirectory(), @"ClientImages");
                var uploadimg = Path.Combine(mediaPath, fileName + extention);
                using (Stream fileStreams = new FileStream(uploadimg, FileMode.Create))
                {
                    await image.CopyToAsync(fileStreams);
                    fileStreams.Flush();
                    fileStreams.Dispose();
                }
                return path + fileName + extention;
        }
    }
}
