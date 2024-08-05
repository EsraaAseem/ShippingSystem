using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shippings.Quries.GetRepresentativeShipping
{
    internal class RepresentativeShippingQueryHandler : IQueryHandler<RepresentativeShippingQuery, BaseResponse>
    {
        private readonly IShippingServiceQuery _shippingService;
        public RepresentativeShippingQueryHandler(IShippingServiceQuery shippingService)
        {
            _shippingService = shippingService;
        }

        public async Task<BaseResponse> Handle(RepresentativeShippingQuery request, CancellationToken cancellationToken)
        {
            var shipping = await _shippingService.GetCourierShipping(request.courierId);
            return await BaseResponse.SuccessResponseWithDataAsync(shipping);
        }
    }
}
