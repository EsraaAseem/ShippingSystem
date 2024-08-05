using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Shippings.Quries.GetSystemShippings
{
    internal class SystemShippingsQueryHandler : IQueryHandler<ShippingsQuery, BaseResponse>
    {
        public Task<BaseResponse> Handle(ShippingsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
