using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFees;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesBeackup
{
    internal class PaidDeliveryFeesBeackupHandler : ICommandHandler<PaidDeliveryFeesBeackupCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PaidDeliveryFeesBeackupHandler> _localization;
        public PaidDeliveryFeesBeackupHandler(IUnitOfWork unitOfWork, IStringLocalizer<PaidDeliveryFeesBeackupHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(PaidDeliveryFeesBeackupCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.EmployeeRepository.PaidDeliveryFeesBeackup(request.representativeId);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["SuccessFeesPaidUpdate"].Value);
        }
    }
}
