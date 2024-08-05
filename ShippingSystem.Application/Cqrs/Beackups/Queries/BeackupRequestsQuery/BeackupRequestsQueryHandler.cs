using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientShipping;
using ShippingSystem.Application.Cqrs.Beackups.Responses;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupRequestsQuery
{
    internal class BeackupRequestsQueryHandler : IQueryHandler<BeackupRequestsQuery, BaseResponse>
    {
        private readonly IBeackupServiceQuery _beackupService;
        public BeackupRequestsQueryHandler(IBeackupServiceQuery beackupService)
        {
            _beackupService = beackupService;
        }

        public async Task<BaseResponse> Handle(BeackupRequestsQuery request, CancellationToken cancellationToken)
        {
            var beackups = await _beackupService.BeackupRequests().Select(b => new BeackupResponse
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
