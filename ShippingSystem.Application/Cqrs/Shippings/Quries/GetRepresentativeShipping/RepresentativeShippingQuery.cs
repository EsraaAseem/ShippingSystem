using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shippings.Quries.GetRepresentativeShipping
{
    public record RepresentativeShippingQuery(string courierId):IQuery<BaseResponse>;
  
}
