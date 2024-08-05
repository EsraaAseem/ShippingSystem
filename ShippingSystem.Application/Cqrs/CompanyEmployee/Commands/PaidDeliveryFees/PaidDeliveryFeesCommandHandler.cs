using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFees
{
    internal class PaidDeliveryFeesCommandHandler : ICommandHandler<PaidDeliveryFeesCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PaidDeliveryFeesCommandHandler> _localization;
        public PaidDeliveryFeesCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<PaidDeliveryFeesCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(PaidDeliveryFeesCommand request, CancellationToken cancellationToken)
        {
             _unitOfWork.EmployeeRepository.PaidDeliveryFees(request.representativeId);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["SuccessFeesPaidUpdate"].Value);
        }
    }
}
