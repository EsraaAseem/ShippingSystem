using Mapster;
using ShippingSystem.Application.Cqrs.Cities.Response.CitiesResponse;
using ShippingSystem.Domain.Models;
namespace ShippingSystem.Application.Mapping
{
    internal class CityMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<City, CityResponse>();
        }
    }
}
