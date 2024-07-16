using Microsoft.AspNetCore.Http;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister
{
    public record ClientRegCommand(string email,string userName,
        string password,
        string name,
        string? phoneNumber,
        string address
        ,string companyName,
        IFormFile logo,
        string Covernorate,
        string city,
        string branch) : ICommand<BaseResponse>;

}
