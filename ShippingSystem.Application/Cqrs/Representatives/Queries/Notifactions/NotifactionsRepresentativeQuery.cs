using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Representatives.Queries.Notifactions
{
    public record NotifactionsRepresentativeQuery(string representativeId):IQuery<BaseResponse>;
}
