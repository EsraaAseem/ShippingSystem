using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Representatives.Queries.DeliveryFees
{
    public record DeliveryFeesQuery(string representativeId):IQuery<BaseResponse>;
}
