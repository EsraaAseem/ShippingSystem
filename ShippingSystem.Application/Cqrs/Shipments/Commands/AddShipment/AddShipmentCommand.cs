using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment
{
    public record AddShipmentCommand(List<AddProduct> products, string trackingNumber, Guid? backupId,
       Guid cityId,string clientId ,AddReciver reciver, int shipmentTypeId, DateTime? movedDate, Guid shipmentStatusId, PaymentStatus paymentStatus) :ICommand<BaseResponse>;
}
