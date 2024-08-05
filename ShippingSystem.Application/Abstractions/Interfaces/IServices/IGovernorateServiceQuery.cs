using ShippingSystem.Domain.Models;

namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IGovernorateServiceQuery
    {
        Task<List<Governorate>> GetGovernorates();
        Task<Governorate> GetGovernorate(Guid id);
    }
}
