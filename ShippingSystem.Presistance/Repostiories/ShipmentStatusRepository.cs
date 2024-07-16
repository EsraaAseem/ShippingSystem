using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;


namespace ShippingSystem.Presistance.Repostiories
{
    public class ShipmentStatusRepository : Repository<ShipmentStatus>, IShipmentStatusRepository
    {
        public ShipmentStatusRepository(ShippingSystemContext context) : base(context)
        {
        }
    }
}
