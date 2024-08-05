

using ShippingSystem.Domain.Models;

namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IRepresentativeServiceQuery
    {
        Task<Representative> GetRepresentative(string id);
        Task<List<Notification>> GetClientNotifactions(string representativeId);
        Task<List<DeliveryFees>> RepresentativeDeliveryFees(string representativeId);
        double RepresentativeIndebtes(string representativeId);

    }
}
