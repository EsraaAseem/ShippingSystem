using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Cities.Queries.GetCities
{
    public record CitiesQuery():IQuery<BaseResponse>;
}
