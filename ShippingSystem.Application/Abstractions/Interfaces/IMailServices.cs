using Microsoft.AspNetCore.Http;


namespace ShippingSystem.Application.Abstractions.Interfaces
{
    public interface IMailServices
    {
        Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile>? attachments = null);
        string CallOtp();
        bool CheckOtp(string reciveOtp);
    }
}
