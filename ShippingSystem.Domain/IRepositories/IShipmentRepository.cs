using ShippingSystem.Domain.Models;


namespace ShippingSystem.Domain.IRepositories
{
    public interface IShipmentRepository:IRepository<Shipment>
    {
        Task<List<Shipment>> AddShipmentShippingId(Guid beackupId,List<Guid> shipmentIds);
    }
}
