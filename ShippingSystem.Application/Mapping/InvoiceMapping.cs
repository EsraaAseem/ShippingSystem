using Mapster;
using ShippingSystem.Application.Cqrs.ShareResponse;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Mapping
{
    internal interface InvoiceMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Invoice, InvoiceResponse>()
                 .Map(dest => dest.ClientName, src => src.Client.UserName)
                 .Map(dest => dest.CompanyName, src => src.Client.CompanyName)
                 .Map(dest => dest.RepresentativeName, src => src.Representative.FirstName);
                     
        }
    }
}
