using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;


namespace ShippingSystem.Presistance.Repostiories
{
    public class ShipmentStatusRepository : Repository<ShipmentStatus>, IShipmentStatusRepository
    {
        private readonly ShippingSystemContext _context;
        public ShipmentStatusRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task< ShipmentStatus?> GetStatusByName(ShipmentStatuses name)
        {
            return await _context.ShipmentStatuses.FirstOrDefaultAsync(s=>s.ShipmentStatusName == name);
        }
    }
}
