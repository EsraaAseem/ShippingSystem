using ShippingSystem.Domain.Models;


namespace ShippingSystem.Domain.IRepositories
{
    public interface IShippingRepository:IRepository<Shipping>
    {
       Task<Shipping> GetShipping(Guid shippingId);
       // Task<Shipping> UpdateShippingLocation(Guid shippingId);

    }
}
