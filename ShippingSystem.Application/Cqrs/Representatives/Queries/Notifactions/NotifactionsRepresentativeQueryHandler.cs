using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Representatives.Queries.Notifactions
{
    internal class NotifactionsRepresentativeQueryHandler : IQueryHandler<NotifactionsRepresentativeQuery, BaseResponse>
    {
        private readonly IRepresentativeServiceQuery _representativeService;
        private readonly IMapper _mapper;

        public NotifactionsRepresentativeQueryHandler(IRepresentativeServiceQuery representativeService, IMapper mapper)
        {
            _representativeService = representativeService;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(NotifactionsRepresentativeQuery request, CancellationToken cancellationToken)
        {
            var notifactions = _representativeService.GetClientNotifactions(request.representativeId);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<List<Notification>>(notifactions));
        }
    }
}
