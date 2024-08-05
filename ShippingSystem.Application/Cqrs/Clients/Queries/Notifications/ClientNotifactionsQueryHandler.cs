using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.ShareResponse;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Clients.Queries.Notifications
{
    internal class ClientNotifactionsQueryHandler : IQueryHandler<ClientNotifactionsQuery, BaseResponse>
    {
        private readonly IClientServiceQuery _clientService;
        private readonly IMapper _mapper;
        public ClientNotifactionsQueryHandler(IClientServiceQuery clientService,IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }



        public async Task<BaseResponse> Handle(ClientNotifactionsQuery request, CancellationToken cancellationToken)
        {
            var notifactions = await _clientService.GetClientNotifactions(request.clientId);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<List<NotifactionResponse>>(notifactions));
        }
    }
}
