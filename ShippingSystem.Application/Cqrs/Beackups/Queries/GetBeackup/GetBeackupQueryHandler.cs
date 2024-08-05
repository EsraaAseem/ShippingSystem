

using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientShipping;
using ShippingSystem.Application.Cqrs.Beackups.Responses;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Beackups.Queries.GetBeackup
{
    internal class GetBeackupQueryHandler : IQueryHandler<GetBeackupQuery,BaseResponse>
    {
        private readonly IBeackupServiceQuery _beackupService;
        public GetBeackupQueryHandler(IBeackupServiceQuery beackupService)
        {
            _beackupService = beackupService;
        }

        public async Task<BaseResponse> Handle(GetBeackupQuery request, CancellationToken cancellationToken)
        {
            var b = await _beackupService.GetBeackup(request.beackupId);
            var beackup = new BeackupResponse
            {
                orderNumber = b.OrderNumber,
                OrderProcessData = b.StartDeliveryTime,
                ClientName = b.Client.UserName,
                CompanyName = b.Client.CompanyName,
                RepresentativeName = b.Representative.FirstName,
                Status = b.Status.ToString(),
            };
            return await BaseResponse.SuccessResponseWithDataAsync(beackup);
        }
    }
}
