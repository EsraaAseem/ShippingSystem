using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesBeackup
{
    public record PaidDeliveryFeesBeackupCommand(string representativeId):ICommand<BaseResponse>;
}
