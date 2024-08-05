using Mapster;
using ShippingSystem.Application.Cqrs.Representatives.Response;
using ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Mapping
{
    internal class RepresentativeMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Representative, RepresentativeAuthResponse>().Map(dest => dest.ConnectionData.PhoneNumber, src => src.PhoneNumber)
                                .Map(dest => dest.ConnectionData.Email, src => src.Email)
                                                .Map(dest => dest.ConnectionData.EmailConfirmed, src => src.EmailConfirmed)
                .Map(dest => dest.ConnectionData.PhoneConfirmed, src => src.PhoneNumberConfirmed);
            ;
            config.NewConfig<Representative, RepresentativeResponse>();
        }
    }
}
