using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.UpdateEmployeeProfile
{
    public record UpdateEmployeeProfileCommand(string employeeId, string? email, string userName,
        string firstName,
        string lastName,
        string? phoneNumber,
        string address,
        string Covernorate,
        string city,
        string branch) :ICommand<BaseResponse>;
}
