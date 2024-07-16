using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping
{
    internal class AddShippingCommandHandler : ICommandHandler<AddShippingCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddShippingCommandHandler> _localization;
        public AddShippingCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddShippingCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(AddShippingCommand request, CancellationToken cancellationToken)
        { var id = Guid.NewGuid();
            var shipping = Shipping.CreateShipping(id, request.representativeId,
                request.vehicleId, request.startDate, request.locationFrom, request.locationTo);
            await _unitOfWork.ShippingRepository.Add(shipping);
         //   await _unitOfWork.SaveChangesAsync();

            var shipments = _unitOfWork.ShipmentRepository.AddShipmentShippingId(id,request.shipmentsIds);
            foreach ( var shipment in shipments.Result )
            {
                shipment.ShippingId = id;
            }
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["AddShippingSuccess"].Value);
        }
    }
}
