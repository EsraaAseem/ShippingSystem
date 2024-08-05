using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Domain.IRepositories
{
    public interface IShipmentStatusRepository:IRepository<ShipmentStatus>
    {
        Task<ShipmentStatus> GetStatusByName(ShipmentStatuses name);
    }
}
