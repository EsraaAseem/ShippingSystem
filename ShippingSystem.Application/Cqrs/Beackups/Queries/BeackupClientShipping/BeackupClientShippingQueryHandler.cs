using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Beackups.Responses;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientShipping
{
    internal class BeackupClientShippingQueryHandler : IQueryHandler<BeackupClientShippingQuery, BaseResponse>
    {
        private readonly IBeackupServiceQuery _beackupService;
        public BeackupClientShippingQueryHandler(IBeackupServiceQuery beackupService)
        {
            _beackupService = beackupService;
        }

        public async Task<BaseResponse> Handle(BeackupClientShippingQuery request, CancellationToken cancellationToken)
        {
            var beackups = await _beackupService.BeackupClientShipping(request.clientId).Select(b => new BeackupResponse
            {
                orderNumber=b.OrderNumber,
                OrderProcessData=b.StartDeliveryTime,
                ClientName=b.Client.UserName,
                CompanyName=b.Client.CompanyName,
                RepresentativeName=b.Representative.FirstName,
                Status=b.Status.ToString(),
            }).ToListAsync();
            return await BaseResponse.SuccessResponseWithDataAsync(beackups);
        }
    }
}
