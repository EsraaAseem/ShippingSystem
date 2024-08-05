using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesMovingShipments
{
    public record  PaidDeliveryFeesMovingShipmentsCommand (string representativeId):ICommand<BaseResponse>;
}
