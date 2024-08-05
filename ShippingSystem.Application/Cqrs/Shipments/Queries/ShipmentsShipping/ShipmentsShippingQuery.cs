using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsShipping
{
    public record ShipmentsShippingQuery() : IQuery<BaseResponse>;
}
