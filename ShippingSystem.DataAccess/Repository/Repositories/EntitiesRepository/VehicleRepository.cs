using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.BaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;

namespace ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationDbContext _db;
        public VehicleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Vehicle> UpdateVehicleAsync(int Id, VehicleEdit Vehicleupdate)
        {

            var vehicle = await _db.Vehicles.FirstOrDefaultAsync(c => c.Id == Id);
            if (vehicle == null)
                throw new NotFoundException("this Vehicle not found");
                vehicle.Name = Vehicleupdate.Name;
                vehicle.Description = Vehicleupdate.Description;
                _db.Vehicles.Update(vehicle);
                await _db.SaveChangesAsync();
                return vehicle;
        }

    }
}
