using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Presistance.Services
{
    public class ShippingServiceQuery : IShippingServiceQuery
    {
        public Task<Shipping> GetCourierShipping(string courierId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Shipping>> GetShippings()
        {
            throw new NotImplementedException();
        }
    }
}
