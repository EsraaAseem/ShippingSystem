using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackup
{
    internal class UpdateBeackupCommandHandler : ICommandHandler<UpdateBeackupCommand, BaseResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateBeackupCommandHandler> _localization;
        public UpdateBeackupCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateBeackupCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(UpdateBeackupCommand request, CancellationToken cancellationToken)
        {
            var beackup = await _unitOfWork.BeackupRepository.GetBeackupAsync(request.beackupId);
            if (beackup is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundBeackup"].Value);
            beackup.UpdateBeackup(request.startDeliveryTime, request.endDeliveryTime,request.orderNumber,
                request.status,request.representativeId,request.vehicleId);
           await  _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateBeackupSuccess"].Value);
        }
    }
}
