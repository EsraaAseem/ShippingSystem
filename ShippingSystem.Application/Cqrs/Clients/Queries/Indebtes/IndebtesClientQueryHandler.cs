using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.Indebtes
{
    internal class IndebtesClientQueryHandler : IQueryHandler<IndebtesClientQuery, BaseResponse>
    {
        private readonly IShipmentServiceQuery _shipmentService;
        public IndebtesClientQueryHandler(IShipmentServiceQuery shipmentService)
        {
            _shipmentService = shipmentService;
        }
        public async Task<BaseResponse> Handle(IndebtesClientQuery request, CancellationToken cancellationToken)
        {
            double shipments = _shipmentService.GetClientIndebtes(request.clientId);
            return await BaseResponse.SuccessResponseWithDataAsync(shipments);
        }
    }
}
