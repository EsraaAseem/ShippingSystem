

using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.Indebtedness
{
    public record IndebtednessClientQuery(string clientId):IQuery<BaseResponse>;
}