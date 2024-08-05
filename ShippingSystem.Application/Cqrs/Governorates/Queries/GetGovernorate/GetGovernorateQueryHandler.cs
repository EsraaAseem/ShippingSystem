using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Governorates.Queries.GetGovernorate
{
    
    internal class GetGovernorateQueryHandler : IQueryHandler<GetGovernorateQuery, BaseResponse>
    {
        private readonly IGovernorateServiceQuery _governService;
        private readonly IMapper _mapper;

        public GetGovernorateQueryHandler(IGovernorateServiceQuery governService,IMapper mapper)
        {
            _governService = governService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(GetGovernorateQuery request, CancellationToken cancellationToken)
        {
            var govern = await _governService.GetGovernorate(request.id);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<GovernResponse>(govern));
        }
    }
}
