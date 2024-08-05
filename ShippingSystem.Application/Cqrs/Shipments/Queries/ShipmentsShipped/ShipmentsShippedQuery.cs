using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsShipped
{
  public record ShipmentsShippedQuery() : IQuery<BaseResponse>;
}
