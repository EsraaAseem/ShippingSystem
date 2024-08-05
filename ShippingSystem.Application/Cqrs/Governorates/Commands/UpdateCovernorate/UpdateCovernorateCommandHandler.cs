using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Governorates.Commands.UpdateCovernorate
{
    internal class UpdateCovernorateCommandHandler : ICommandHandler<UpdateCovernorateCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateCovernorateCommandHandler> _localization;
        public UpdateCovernorateCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateCovernorateCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(UpdateCovernorateCommand request, CancellationToken cancellationToken)
        {
            var govern = await _unitOfWork.GovernorateRepository.GetGovernorate(request.id);
            if (govern is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundGovern"].Value);
            govern.UpdateCovernorate(request.name);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateGovernSuccess"].Value);

        }
    }
}
