using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientShipping
{
    public record BeackupClientShippingQuery(string clientId):IQuery<BaseResponse>;
}
