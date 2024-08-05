

using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Representatives.Queries.DeliveryFees
{
    internal class DeliveryFeesQueryHandler : IQueryHandler<DeliveryFeesQuery, BaseResponse>
    {
        private readonly IRepresentativeServiceQuery _representativeService;
        private readonly IMapper _mapper;
        public DeliveryFeesQueryHandler(IRepresentativeServiceQuery representativeService,IMapper mapper)
        {
            _representativeService = representativeService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(DeliveryFeesQuery request, CancellationToken cancellationToken)
        {
            var fees = await _representativeService.RepresentativeDeliveryFees(request.representativeId);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<List<DeliveryFeesResponse>>(fees));
        }
    }
}
