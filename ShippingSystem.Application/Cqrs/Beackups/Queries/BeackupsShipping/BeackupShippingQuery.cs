using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupsShipping
{
    public record BeackupShippingQuery():IQuery<BaseResponse>;
}
