using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientRquests
{
    public record BeackupClientRequestsQuery(string clientId):IQuery<BaseResponse>;
}
