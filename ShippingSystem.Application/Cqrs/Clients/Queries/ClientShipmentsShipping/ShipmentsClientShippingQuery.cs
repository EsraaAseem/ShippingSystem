using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsShipping
{
    public record ShipmentsClientShippingQuery(string clientId):IQuery<BaseResponse>;
  
}
