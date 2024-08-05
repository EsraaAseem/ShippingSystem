using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Governorates.Queries.GetGovernorate;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Governorates.Queries.GetGovernorates
{
    internal class GetGovernoratesQueryHandler : IQueryHandler<GetGovernoratesQuery, BaseResponse>
    {
        private readonly IGovernorateServiceQuery _governService;
        private readonly IMapper _mapper;

        public GetGovernoratesQueryHandler(IGovernorateServiceQuery governService, IMapper mapper)
        {
            _governService = governService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(GetGovernoratesQuery request, CancellationToken cancellationToken)
        {
            var govern = await _governService.GetGovernorates();
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<List<GovernResponse>>(govern));
        }
     
    }
}
