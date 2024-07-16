

namespace ShippingSystem.Domain.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Remove(T entity);
    }
}
