using ShippingSystem.Domain.Models;


namespace ShippingSystem.Domain.IRepositories
{
    public interface IRepresentativeRepository:IRepository<Representative>
    {
        Task<Representative> GetRepresentativeAsync(string id);
    }
}
