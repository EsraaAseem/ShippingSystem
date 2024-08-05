

using ShippingSystem.Domain.Models;

namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IShippingServiceQuery
    {
        Task<List<Shipping>> GetShippings();
        Task<Shipping> GetCourierShipping(string courierId );
    }
}
