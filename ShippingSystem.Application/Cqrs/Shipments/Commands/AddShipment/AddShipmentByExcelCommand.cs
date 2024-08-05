using Microsoft.AspNetCore.Http;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment
{
    public record AddShipmentByExcelCommand(IFormFile file) :ICommand<BaseResponse>;
}
