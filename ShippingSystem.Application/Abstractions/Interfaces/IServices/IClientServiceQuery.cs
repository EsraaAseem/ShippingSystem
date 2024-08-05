using ShippingSystem.Domain.Models;


namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IClientServiceQuery
    {
        Task<Client> GetClientAsync(string id);
        Task<List<Notification>> GetClientNotifactions(string clientId);
    }
}
