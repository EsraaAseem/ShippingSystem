

using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup
{
    internal class AddBeackupCommandHandler : ICommandHandler<AddBeackupCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddBeackupCommandHandler> _localization;
        public AddBeackupCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddBeackupCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(AddBeackupCommand request, CancellationToken cancellationToken)
        {
            var beackup=Beackup.CreateBeackup(Guid.NewGuid(),request.startDeliveryTime,request.endDeliveryTime,request.orderNumber,
                request.status,request.clientId,request.representativeId,request.vehicleId);
           await _unitOfWork.BeackupRepository.Add(beackup); ;
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["AddBeackupsuccess"].Value);
        }
    }
}
