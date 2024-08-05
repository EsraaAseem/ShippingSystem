using ShippingSystem.Domain.Models;
 

namespace ShippingSystem.Domain.IRepositories
{
    public interface IBeackupRepository:IRepository<Beackup>
    {
        Task<Beackup> GetBeackupAsync(Guid id);
    }
}
