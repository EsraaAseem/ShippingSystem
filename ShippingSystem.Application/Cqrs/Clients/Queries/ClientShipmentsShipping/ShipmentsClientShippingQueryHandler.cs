using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Clients.Queries.ShipedOrders;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsShipping
{
    internal class ShipmentsClientShippingQueryHandler:IQueryHandler<ShipmentsClientShippingQuery,BaseResponse>
    {

        private readonly IShipmentServiceQuery _shipmentService;
        public ShipmentsClientShippingQueryHandler(IShipmentServiceQuery shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<BaseResponse> Handle(ShipmentsClientShippingQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentService.GetClientShipmentsShipping(request.clientId);
            return await BaseResponse.SuccessResponseWithDataAsync(shipments);
        }
    }
}
