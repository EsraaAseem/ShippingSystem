using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle
{
    internal class AddVehicleCommandHandler : ICommandHandler<AddVehicleCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddVehicleCommandHandler> _localization;
        public AddVehicleCommandHandler(IUnitOfWork unitOfWork,IStringLocalizer<AddVehicleCommandHandler> localization)
        {
           _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            if( _unitOfWork.VehicleRepository.GetVehicleByName(request.name))
             return await BaseResponse.BadRequestResponsAsync(_localization["vehicleAlreadyExist"].Value);
            var vehicle = Vehicle.CreateVehicle(Guid.NewGuid(), request.name, request.description);

          await _unitOfWork.VehicleRepository.Add(vehicle);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["CreateVehicleSuccess"].Value);
        }
    }
}
