using Mapster;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Mapping
{
    internal class ShipmentMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Shipment, ShipmentsClientsResponse>()
             .Map(dest => dest.TrackingNumber, src => src.TrackingNumber)
            .Map(dest => dest.Products, src => src.Products.Select(p => p.Adapt<ProductCLientResponse>()))
            .Map(dest => dest.Reciver, src => src.Reciver.Adapt<ReciverClientResponse>())
            .Map(dest => dest.ProccedDate, src => src.ProccedDate)
            .Map(dest => dest.ShippmentStatus, src => src.ShippmentStatus.ShipmentStatusName)
            .Map(dest => dest.QrCodeUrl, src => src.QrCodeUrl);
           // .Map(dest => dest.TotalPrice, src => src.TotalPrice)
           // .Map(dest => dest.ShipmentType, src => src.ShipmentType.Name);

        }
    }  
}
