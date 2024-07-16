using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        private readonly ShippingSystemContext _context;
        public ShipmentRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List< Shipment>> AddShipmentShippingId(Guid shipping, List<Guid> shipmentIds)
        {
            return await _context.Shipments
                .Where(s => shipmentIds.Contains(s.Id)).ToListAsync();
        }
    }

}
