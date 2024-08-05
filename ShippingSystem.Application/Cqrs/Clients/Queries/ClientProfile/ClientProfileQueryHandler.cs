using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Clients.Queries.ClientProfile
{
    internal class ClientProfileQueryHandler : IQueryHandler<ClientProfileQuery, BaseResponse>
    {
        private readonly IClientServiceQuery _clientService;
        private readonly IMapper _mapper;
        public ClientProfileQueryHandler(IClientServiceQuery clientService,IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ClientProfileQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientService.GetClientAsync(request.clientId);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<ClientResponse>(client));
        }
    }
}
