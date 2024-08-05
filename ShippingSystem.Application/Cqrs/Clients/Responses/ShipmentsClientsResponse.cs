

namespace ShippingSystem.Application.Cqrs.Clients.Responses
{
    public class ShipmentsClientsResponse
    {
        public string TrackingNumber { get; set; }
        public IReadOnlyCollection<ProductCLientResponse> Products { get; set; }
        public ReciverClientResponse Reciver { get; set; }
        public string ShipmentType { get; set; }
        public DateTime? ProccedDate { get; set; }
        public string ShippmentStatus { get; set; }
        public string? QrCodeUrl { get;  set; }
        public double TotalPrice { get; set; }
        public double indebtes { get; set; }
        public double Indebtedness { get; set; }
    }
}
