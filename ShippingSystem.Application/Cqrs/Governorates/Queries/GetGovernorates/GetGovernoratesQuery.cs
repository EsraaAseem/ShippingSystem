using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Governorates.Queries.GetGovernorates
{
    public record GetGovernoratesQuery():IQuery<BaseResponse>;
}
