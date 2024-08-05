using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFees;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesInvoices
{
    internal class PaidDeliveryFeesInvoicesCommandHandler : ICommandHandler<PaidDeliveryFeesInvoicesCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PaidDeliveryFeesInvoicesCommandHandler> _localization;
        public PaidDeliveryFeesInvoicesCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<PaidDeliveryFeesInvoicesCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(PaidDeliveryFeesInvoicesCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.EmployeeRepository.PaidDeliveryFeesInvoices(request.representativeId);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["SuccessFeesPaidUpdate"].Value);
        }

     
    }
}
