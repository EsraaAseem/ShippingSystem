using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Shipments.Commands.FundsSettledShipment
{
    public record FundsSettledShipmentCommand(Guid deliveryId,DeliveringType deliveryType):ICommand<BaseResponse>;
}
