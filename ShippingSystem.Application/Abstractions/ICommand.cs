using MediatR;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Abstractions
{
    public interface ICommand : IRequest<BaseResponse>
    {
    }

    public interface ICommand<TResponse> : IRequest<BaseResponse>
    {
    }
}
