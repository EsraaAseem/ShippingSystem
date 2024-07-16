using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Governorates.Commands.AddGovernorate
{
    internal class AddGovernorateCommandHandler:ICommandHandler<AddGovernorateCommand,BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddVehicleCommandHandler> _localization;
        public AddGovernorateCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddVehicleCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(AddGovernorateCommand request, CancellationToken cancellationToken)
        {
            if (_unitOfWork.GovernorateRepository.CheckGovernorate(request.name))
                return await BaseResponse.BadRequestResponsAsync(_localization["GovernorateAlreadyExist"].Value);
            var governorate = Governorate.CreateCovernorate(Guid.NewGuid(), request.name);

            await _unitOfWork.GovernorateRepository.Add(governorate);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["CreateGovernorateSuccess"].Value);
        }
    }
}
