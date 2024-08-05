using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.UpdateShipmentStatus
{
    public record  UpdateShipmentStatusCommand(Guid shipmentId,ShipmentStatuses status=ShipmentStatuses.DelegatedRepresentative,
        List<ProductsAmount>? productsAmounts=null):ICommand<BaseResponse>;
    
}
