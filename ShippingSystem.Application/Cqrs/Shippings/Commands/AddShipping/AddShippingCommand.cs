using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping
{
    public record AddShippingCommand(string representativeId, Guid vehicleId, DateTime startDate,
            string locationFrom, string locationTo,List<Guid> shipmentsIds) :ICommand<BaseResponse>;
    
}
