using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Invoices.Quries.GetClientInvoices
{
    public record ClientInvoicesQuery(string? clientId):IQuery<BaseResponse>;
}
