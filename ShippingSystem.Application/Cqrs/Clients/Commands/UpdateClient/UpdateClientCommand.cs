using Microsoft.AspNetCore.Http;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Clients.Commands.UpdateClient
{
    public record UpdateClientCommand(string clientId,string email,string userName,
        string name,
        string? phoneNumber,
        string address
        , string companyName,
        IFormFile logo,
        string Covernorate,
        string city,
        string branch) :ICommand<BaseResponse>;
}
