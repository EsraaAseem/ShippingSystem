using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Cities.Response.CitiesResponse;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Cities.Queries.GetCity
{
    internal class CityQueryHandler : IQueryHandler<CityQuery, BaseResponse>
    {
        private readonly ICityQueryService _cityService;
        private readonly IMapper _mapper;
        public CityQueryHandler(ICityQueryService cityService,IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CityQuery request, CancellationToken cancellationToken)
        {
            var response = await _cityService.GetCityAsync(request.name);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<CityResponse>(response));
        }
    }
}
