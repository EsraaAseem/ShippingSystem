using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackup
{
    public record UpdateBeackupCommand(Guid beackupId, DateTime? startDeliveryTime, DateTime endDeliveryTime,
            int orderNumber, Beackupstatus status, string representativeId, Guid vehicleId) :ICommand<BaseResponse>;
}
