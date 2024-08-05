using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefused
{
  public record ShipmentsClientRejectedQuery(string clientId) : IQuery<BaseResponse>;
  
}
