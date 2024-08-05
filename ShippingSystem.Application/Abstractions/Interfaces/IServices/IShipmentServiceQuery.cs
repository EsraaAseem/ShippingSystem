using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IShipmentServiceQuery
    {
        Task<List<Shipment>> GetClientShipmentsShipped(string clientId);
        Task<List<Shipment>> GetClientShipmentsShipping(string clientId);
        Task<List<Shipment>> GetClientShipmentsRequests(string clientId);
        Task<List<Shipment>> GetClientShipmentsRejected(string clientId);
        Task<List<Shipment>> GetClientShipmentsRejectedWithPaid(string clientId);
        Task<List<Shipment>> GetShipmentsShipped();
        Task<List<Shipment>> GetShipmentsShipping();
        Task<List<Shipment>> GetShipmentsRequests();
        Task<List<Shipment>> GetShipmentsRejected();
        Task<List<Shipment>> GetShipmentsRejectedWithPaid();
        double GetClientIndebtness(string clientId);
        double GetClientIndebtes(string clientId);

    }
}
