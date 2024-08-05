using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRequests
{
  public record ShipmentsClientRequestsQuery(string clientId):IQuery<BaseResponse>;
 
}
