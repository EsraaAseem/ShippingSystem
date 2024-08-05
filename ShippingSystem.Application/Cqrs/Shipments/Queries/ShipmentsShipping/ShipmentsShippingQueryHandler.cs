using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsShipping
{
    internal class ShipmentsShippingQueryHandler : IQueryHandler<ShipmentsShippingQuery, BaseResponse>
    {

        private readonly IShipmentServiceQuery _shipmentService;
        public ShipmentsShippingQueryHandler(IShipmentServiceQuery shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<BaseResponse> Handle(ShipmentsShippingQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentService.GetShipmentsShipping();
            return await BaseResponse.SuccessResponseWithDataAsync(shipments);
        }
    }
}
