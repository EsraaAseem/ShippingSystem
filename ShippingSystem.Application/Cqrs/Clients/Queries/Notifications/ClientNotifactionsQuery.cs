using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.Notifications
{
    public record ClientNotifactionsQuery(string clientId):IQuery<BaseResponse>;
}
