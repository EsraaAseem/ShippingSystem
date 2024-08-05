using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.Notifactions
{
    public record NotifactionQuery() : IQuery<BaseResponse>;
}
