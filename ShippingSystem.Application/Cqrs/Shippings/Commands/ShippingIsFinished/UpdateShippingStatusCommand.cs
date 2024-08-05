using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shippings.Commands.ShippingIsFinished
{
    public record UpdateShippingStatusCommand(Guid shippingId):ICommand<BaseResponse>;
}
