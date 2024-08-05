using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Representatives.Response;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Representatives.Queries.RepresentativeProfile
{
    internal class RepresentativeProfileQueryHandler : IQueryHandler<RepresentativeProfileQuery, BaseResponse>
    {
        private readonly IRepresentativeServiceQuery _representativeService;
        private readonly IMapper _mapper;

        public RepresentativeProfileQueryHandler(IRepresentativeServiceQuery representativeService,IMapper mapper)
        {
            _representativeService = representativeService;
                _mapper = mapper;

        }

        public async Task<BaseResponse> Handle(RepresentativeProfileQuery request, CancellationToken cancellationToken)
        {
            var representative = await _representativeService.GetRepresentative(request.representativeId);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<RepresentativeResponse>(representative));
        }
    }
}
