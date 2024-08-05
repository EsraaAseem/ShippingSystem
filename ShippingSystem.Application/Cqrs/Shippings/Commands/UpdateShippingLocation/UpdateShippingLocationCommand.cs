using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Shippings.Commands.UpdateShippingLocation
{
    public record UpdateShippingLocationCommand(Guid shippingId,string currentLocation):ICommand<BaseResponse>;
}
