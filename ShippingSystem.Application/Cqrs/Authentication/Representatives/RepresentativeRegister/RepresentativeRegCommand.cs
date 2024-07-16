using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Authentication.Representatives.RepresentativeRegister
{
    public record RepresentativeRegCommand(string email,string userName,
        string password,
        string firstName,
        string lastName,
        string? phoneNumber,
        string address,
        string Covernorate,
        string branch,string city) : ICommand<BaseResponse>;
}
