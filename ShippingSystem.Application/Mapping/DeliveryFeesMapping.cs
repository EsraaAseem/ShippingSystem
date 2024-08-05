using Mapster;
using ShippingSystem.Application.Cqrs.Cities.Response.CitiesResponse;
using ShippingSystem.Application.Cqrs.Representatives.Queries.DeliveryFees;
using ShippingSystem.Domain.Models;
namespace ShippingSystem.Application.Mapping
{
    internal class DeliveryFeesMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DeliveryFees, DeliveryFeesResponse>();
        }
    }
}
