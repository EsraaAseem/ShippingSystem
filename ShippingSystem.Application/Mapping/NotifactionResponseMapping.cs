using Mapster;
using ShippingSystem.Application.Cqrs.ShareResponse;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Mapping
{
    internal class NotifactionResponseMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<NotifactionResponse, Notification>()
                .Map(dest => dest.Type, src => src.Type.ToString());
        }
    }
}
