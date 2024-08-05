using ShippingSystem.Domain.Models;


namespace ShippingSystem.Domain.IRepositories
{
    public interface IShipmentRepository:IRepository<Shipment>
    {
        Task<List<Shipment>> AddShipmentShippingId(List<Guid> shipmentIds);
        Task<Shipment?> GetShipmentAsync(Guid id);
        string GetClientIdAsync(string userName);
        Guid GetCity(string name);
        int GetShipmentTypeId(string name);
        Guid GetShipmentStausId();
    }
}
