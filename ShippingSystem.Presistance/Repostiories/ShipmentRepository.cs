using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Enums;
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

        public async Task<List< Shipment>> AddShipmentShippingId(List<Guid> shipmentIds)
        {
            return await _context.Shipments.Include(s=>s.City).Include(s=>s.ShippmentStatus).Include(s=>s.ShipmentType)
                .Where(s => shipmentIds.Contains(s.Id)).ToListAsync();
        }
        public async Task<Shipment?> GetShipmentAsync(Guid id)
        {
            return await _context.Shipments.FindAsync(id);
        }
        public Guid GetCity(string name)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Name == name);
            return city.Id;
        }
        public Guid GetShipmentStausId()
        {
            return _context.ShipmentStatuses.FirstOrDefault(c => c.ShipmentStatusName == ShipmentStatuses.UnConfirmed).Id;
        }
        public string GetClientIdAsync(string userName)
        {
            var client = _context.Clients.FirstOrDefault(c => c.UserName == userName);
            return client.Id;
        }
        public int GetShipmentTypeId(string name)
        {
           return _context.ShipmentTypes.FirstOrDefault(s=>s.Name==name).Id;   
            
        }

    }

}
