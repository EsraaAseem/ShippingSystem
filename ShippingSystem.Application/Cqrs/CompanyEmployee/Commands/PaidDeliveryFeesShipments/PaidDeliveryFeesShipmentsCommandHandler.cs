using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesShipments
{
    internal class PaidDeliveryFeesShipmentsCommandHandler : ICommandHandler<PaidDeliveryFeesShipmentsCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<PaidDeliveryFeesShipmentsCommandHandler> _localization;
        public PaidDeliveryFeesShipmentsCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<PaidDeliveryFeesShipmentsCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(PaidDeliveryFeesShipmentsCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.EmployeeRepository.PaidDeliveryFeesShipments(request.representativeId);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["SuccessFeesPaidUpdate"].Value);
        }
    }
}
