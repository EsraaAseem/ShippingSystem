using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.FundsSettledShipment
{
    internal class FundsSettledShipmentCommandHandler : ICommandHandler<FundsSettledShipmentCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<FundsSettledShipmentCommandHandler> _localization;
        public FundsSettledShipmentCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<FundsSettledShipmentCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(FundsSettledShipmentCommand request, CancellationToken cancellationToken)
        {
            DeliveryFees deliveryFees = null;
            double shippingPrice = 0;
            var cityName = "";
            var id=Guid.NewGuid();
            if(request.deliveryType==DeliveringType.Shipment)
            {
                var shipment = await _unitOfWork.ShipmentRepository.GetShipmentAsync(request.deliveryId);
                if(shipment == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundShipment"].Value);
                shipment.FundsSettled();
                var percent = shipment.City.CourierShippingCostPercent;

                deliveryFees = DeliveryFees.CreateDeliveryFees(id,shipment.Shipping.RepresentativeId, shipment.Id, request.deliveryType, shipment.ShippingPrice()
                    , percent, DeliveringCost(shipment.ShippingPrice(), percent));

            }
            else if(request.deliveryType==DeliveringType.Invoice)
            {
                var invoice=await _unitOfWork.InvoiceRepository.GetInvoiceAsync(request.deliveryId);
                if(invoice == null)
                    return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundBeackup"].Value);
                var city = await GetCity(invoice.Client.City);
                deliveryFees = DeliveryFees.CreateDeliveryFees(id,invoice.RepresentativeId ,invoice.Id, request.deliveryType, city.InvoiceDeliveryCost
                   , city.CourierInvoiceDeliveryCostPercent, DeliveringCost(city.InvoiceDeliveryCost, city.CourierInvoiceDeliveryCostPercent));
            }
            else if (request.deliveryType == DeliveringType.Beackup)
            {
                var beackup = await _unitOfWork.BeackupRepository.GetBeackupAsync(request.deliveryId);
                if (beackup == null)
                    return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundBeackup"].Value);
                var city = await GetCity(beackup.Client.City);
                deliveryFees = DeliveryFees.CreateDeliveryFees(id,beackup.RepresentativeId ,beackup.Id, request.deliveryType, city.BeackupDeliveryCost
                   , city.CourierBeackupDeliveryCostPercent, DeliveringCost(city.BeackupDeliveryCost, city.CourierBeackupDeliveryCostPercent));
            }
            await _unitOfWork.DeliveryFeesRepository.Add(deliveryFees);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateShipmentSuccess"].Value);
        }
        private double DeliveringCost(double deliveryCost,double percent)
        {
            var pre = percent / 100;
            return pre * deliveryCost;
        }
        private async Task< City> GetCity(string city)
        {
            return await _unitOfWork.CityRepository.GetCityAsync(city);
        }
    }
}
