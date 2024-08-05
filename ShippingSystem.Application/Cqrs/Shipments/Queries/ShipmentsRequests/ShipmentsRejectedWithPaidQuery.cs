using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsRequests
{
    public record ShipmentsRejectedWithPaidQuery() : IQuery<BaseResponse>;

}
