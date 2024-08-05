using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Representatives.Queries.Indebtes
{
    internal class IndebtesRepresentativeQueryHandler : IQueryHandler<IndebtesRepresentativeQuery, BaseResponse>
    {

        private readonly IRepresentativeServiceQuery _representativeService;
        public IndebtesRepresentativeQueryHandler(IRepresentativeServiceQuery representativeService)
        {
            _representativeService = representativeService;
        }
        public async Task<BaseResponse> Handle(IndebtesRepresentativeQuery request, CancellationToken cancellationToken)
        {
            var prices = _representativeService.RepresentativeIndebtes(request.representativeId);
            return await BaseResponse.SuccessResponseWithDataAsync($"the representative Cost is : {prices}");
        }
    }
}
