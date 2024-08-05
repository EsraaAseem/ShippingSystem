using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesMovingShipments
{
    internal class PaidDeliveryFeesMovingShipmentsCommandHandler : ICommandHandler<PaidDeliveryFeesMovingShipmentsCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PaidDeliveryFeesMovingShipmentsCommandHandler> _localization;
        public PaidDeliveryFeesMovingShipmentsCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<PaidDeliveryFeesMovingShipmentsCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(PaidDeliveryFeesMovingShipmentsCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.EmployeeRepository.PaidDeliveryFeesMovingShipments(request.representativeId);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["SuccessFeesPaidUpdate"].Value);
        }
    }
}
