using Mapster;
using ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Mapping
{
    internal class ClientMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ClientAddRequest,Client>()
                .Map(dest => dest.Address, src => src.StreetAddress)
                .Map(dest => dest.City, src => src.City);
            config.NewConfig<Client,ClientAuthResponse>().Map(dest => dest.ConnectionData.PhoneNumber, src => src.PhoneNumber)
                                .Map(dest => dest.ConnectionData.Email, src => src.Email)
                                                .Map(dest => dest.ConnectionData.EmailConfirmed, src => src.EmailConfirmed)
                .Map(dest => dest.ConnectionData.PhoneConfirmed, src => src.PhoneNumberConfirmed)
                        .Map(dest => dest.City, src => src.City);
          

        }
    }
}
