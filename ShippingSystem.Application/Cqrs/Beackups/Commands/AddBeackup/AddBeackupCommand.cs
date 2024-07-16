using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup
{
    public record AddBeackupCommand(DateTime? startDeliveryTime, DateTime endDeliveryTime, int orderNumber, Beackupstatus status,
        string clientId, string representativeId, Guid vehicleId) :ICommand<BaseResponse>;
}
