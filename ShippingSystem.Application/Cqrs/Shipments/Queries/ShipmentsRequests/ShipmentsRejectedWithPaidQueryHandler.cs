

using MapsterMapper;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsRequests
{
    internal class ShipmentsRejectedWithPaidQueryHandler : IQueryHandler<ShipmentsRejectedWithPaidQuery, BaseResponse>
    {

        private readonly IShipmentServiceQuery _shipmentService;
        private readonly IMapper _mapper;
        public ShipmentsRejectedWithPaidQueryHandler(IShipmentServiceQuery shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ShipmentsRejectedWithPaidQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentService.GetShipmentsRequests();
            var ships = _mapper.Map<List<ShipmentsClientsResponse>>(shipments);
            return await BaseResponse.SuccessResponseWithDataAsync(ships);

        }
    }
}
