using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.UpdateShipmentStatus
{
    internal class UpdateShipmentStatusCommandHandler : ICommandHandler<UpdateShipmentStatusCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateShipmentStatusCommandHandler> _localization;
        public UpdateShipmentStatusCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateShipmentStatusCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(UpdateShipmentStatusCommand request, CancellationToken cancellationToken)
        {
            var shipment = await _unitOfWork.ShipmentRepository.GetShipmentAsync(request.shipmentId);
            var shipmentStatus = await _unitOfWork.ShipmentStatusRepository.GetStatusByName(request.status);
            if (shipment == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundShipment"].Value);
            shipment.UpdateShipmentStatus(shipmentStatus);
            if (request.status == ShipmentStatuses.ReturnedWithPaid || request.status == ShipmentStatuses.Returned)
                foreach (var pro in shipment.Products)
                    pro.UpdateRecivedAmount(0);
            else if(request.status== ShipmentStatuses.RecivedPartial)
                foreach (var pro in request.productsAmounts)
                {
                    var proShip = shipment.Products.FirstOrDefault(p => p.ProductName == pro.productName);
                    if (proShip is not null)
                        proShip.UpdateRecivedAmount(pro.amountRecived);
                }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateShipmentSuccess"].Value);
        }
    }
}
