

using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Invoices.Commands.CreateInvoice
{
    public record CreateInvoiceCommand(List<Guid> shipmentsIds):ICommand<BaseResponse>;
}
