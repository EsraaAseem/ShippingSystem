using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Service.ImagesService
{
    public interface IPhotoService
    {
        Task<string> UploadImageAsync(IFormFile image);
        Task<bool> RemoveImageAsync(string url);
        Task<string> UpdateImageAsync(string oldUrl, IFormFile newMedia);
    }
}
