using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFees
{
    public record PaidDeliveryFeesCommand(string representativeId):ICommand<BaseResponse>;
}
