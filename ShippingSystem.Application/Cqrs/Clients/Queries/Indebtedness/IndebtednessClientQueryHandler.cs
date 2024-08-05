

using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Clients.Queries.ShipedOrders;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.Indebtedness
{
    internal class IndebtednessClientQueryHandler : IQueryHandler<IndebtednessClientQuery, BaseResponse>
    {
        private readonly IShipmentServiceQuery _shipmentService;
        public IndebtednessClientQueryHandler(IShipmentServiceQuery shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<BaseResponse> Handle(IndebtednessClientQuery request, CancellationToken cancellationToken)
        {
            double shipments =  _shipmentService.GetClientIndebtness(request.clientId);
            return await BaseResponse.SuccessResponseWithDataAsync(shipments);
        }
    }
}