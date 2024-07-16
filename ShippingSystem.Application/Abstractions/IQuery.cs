using MediatR;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Abstractions
{
    public interface IQuery<TResponse> : IRequest<BaseResponse>
    {
    }
}
