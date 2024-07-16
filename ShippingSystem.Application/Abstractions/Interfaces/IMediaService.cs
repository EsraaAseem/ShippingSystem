using Microsoft.AspNetCore.Http;


namespace ShippingSystem.Application.Abstractions.Interfaces
{
    public interface IMediaService
    {
        Task<string> UploadImageAsync(IFormFile file, string folderName);
    }
}
