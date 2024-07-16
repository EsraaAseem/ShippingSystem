using ShippingSystem.Domain.Models;

namespace ShippingSystem.Domain.IRepositories
{
    public interface IVehicleRepository:IRepository<Vehicle>
    {
        Task<Vehicle> GetVehicle(Guid id);
        bool GetVehicleByName(string name);
    }
}
