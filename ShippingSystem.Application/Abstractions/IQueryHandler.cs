using MediatR;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, BaseResponse>
    where TQuery : IQuery<TResponse>
    {
    }
}
