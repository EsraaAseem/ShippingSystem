using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.RejectAddClient
{
    public record RejectAddClientCommand(Guid id) : ICommand<BaseResponse>;
}
