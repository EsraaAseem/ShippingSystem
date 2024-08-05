using ShippingSystem.Domain.Models;


namespace ShippingSystem.Domain.IRepositories
{
    public interface IGovernorateRepository:IRepository<Governorate>
    {
        bool CheckGovernorate(string name);
       Task< Governorate> GetGovernorate(Guid id);
    }
}
