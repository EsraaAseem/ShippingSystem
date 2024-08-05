using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Governorates.Queries.GetGovernorate
{
    public record GetGovernorateQuery(Guid id):IQuery<BaseResponse>;
}
