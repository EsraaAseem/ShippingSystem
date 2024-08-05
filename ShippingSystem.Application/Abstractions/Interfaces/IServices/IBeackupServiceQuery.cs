using ShippingSystem.Domain.Models;

namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IBeackupServiceQuery
    {
        IQueryable<Beackup> BeackupClientRequests(string clientId);
        IQueryable<Beackup> BeackupClientShipping(string clientId);
        IQueryable<Beackup> BeackupRequests();
        IQueryable<Beackup> BeackupsShipping();
        Task<Beackup?> GetBeackup(Guid id);    }
}
