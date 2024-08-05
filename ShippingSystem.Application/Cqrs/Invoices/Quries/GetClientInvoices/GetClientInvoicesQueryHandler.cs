using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.ShareResponse;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Invoices.Quries.GetClientInvoices
{
    internal class GetClientInvoicesQueryHandler : IQueryHandler<ClientInvoicesQuery, BaseResponse>
    {
        private readonly IInvoiceServiceQuery _invoiceService;
        private readonly IMapper _mapper;
        public GetClientInvoicesQueryHandler(IInvoiceServiceQuery invoiceService,IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ClientInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceService.GetInvoices(request.clientId);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<List<InvoiceResponse>>(invoices));
        }
    }
}
