using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IVehicleServiceQuery
    {
      Task<List<Vehicle>> GetVehicles();
    }
}
