using Mapster;
using ShippingSystem.Application.Cqrs.Governorates;
using ShippingSystem.Domain.Models;

namespace ShippingSystem.Application.Mapping
{
    internal class GovernMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Governorate, GovernResponse>();
        }
    }
}
