using ShippingSystem.Domain.Models;

namespace ShippingSystem.Domain.IRepositories
{
    public interface IClientAddRequestRepository : IRepository<ClientAddRequest>
    {
        bool CheckClientRequestEmail(string email);
        bool CheckClientRequestUserName(string userName);
        Task<ClientAddRequest> GetClientRequest(Guid id);
    }
}
