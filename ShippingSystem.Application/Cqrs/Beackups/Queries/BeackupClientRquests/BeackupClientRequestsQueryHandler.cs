using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientShipping;
using ShippingSystem.Application.Cqrs.Beackups.Responses;
using ShippingSystem.Shared;
using System;

using Microsoft.EntityFrameworkCore;

namespace ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientRquests
{
    internal class BeackupClientRequestsQueryHandler : IQueryHandler<BeackupClientRequestsQuery, BaseResponse>
    {
        private readonly IBeackupServiceQuery _beackupService;
        public BeackupClientRequestsQueryHandler(IBeackupServiceQuery beackupService)
        {
            _beackupService = beackupService;
        }

        public async Task<BaseResponse> Handle(BeackupClientRequestsQuery request, CancellationToken cancellationToken)
        {
            var beackups = await _beackupService.BeackupClientRequests(request.clientId).Select(b => new BeackupResponse
            {
                orderNumber = b.OrderNumber,
                OrderProcessData = b.StartDeliveryTime,
                ClientName = b.Client.UserName,
                CompanyName = b.Client.CompanyName,
                RepresentativeName = b.Representative.FirstName,
                Status = b.Status.ToString(),
            }).ToListAsync();
            return await BaseResponse.SuccessResponseWithDataAsync(beackups);
        }
    }
}
