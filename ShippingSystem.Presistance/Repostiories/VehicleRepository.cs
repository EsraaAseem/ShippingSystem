
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private ShippingSystemContext _context;
        public VehicleRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Vehicle?> GetVehicle(Guid id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public bool GetVehicleByName(string name)
        {
            return  _context.Vehicles.Any(v => v.Name == name ) ;
        }
    }
}
