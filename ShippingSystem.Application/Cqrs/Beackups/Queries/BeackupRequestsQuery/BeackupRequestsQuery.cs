using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupRequestsQuery
{
    public record BeackupRequestsQuery():IQuery<BaseResponse>;
}
