

using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Invoices.Commands.CreateInvoice
{
    internal class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, BaseResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<CreateInvoiceCommandHandler> _localization;
        public CreateInvoiceCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<CreateInvoiceCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var shipments = await _unitOfWork.ShipmentRepository.AddShipmentShippingId(request.shipmentsIds);
            var id=Guid.NewGuid();
            double netAccount = 0;
            foreach (var shipment in shipments)
            {
                var pros = "";
                foreach(var pro in shipment.Products)
                {
                    pros += pro.ProductName + " : " + pro.Amount + "/n";
                }
                var invoiceItem = new InvoiceItems(shipment.Id, pros,shipment.Reciver.Name, shipment.Reciver.Email,
                    shipment.ShippingPrice(),shipment.TotalProductsPrice,shipment.TotalPrice,shipment.NetAccount(), id);
                await _unitOfWork.InvoiceItemsRepository.Add(invoiceItem);
                netAccount += shipment.NetAccount();
                Shipment.AddInvoicedStatus(shipment);
            }
            var ship = shipments[0];
            var invoice = Invoice.CreateInvoice(id, ship.ClientId,ship.Shipping.RepresentativeId ,ship.City.BeackupDeliveryCost, netAccount);
            await _unitOfWork.InvoiceRepository.Add(invoice);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["CreateInvoiceSuccess"].Value);
        }
    }
}