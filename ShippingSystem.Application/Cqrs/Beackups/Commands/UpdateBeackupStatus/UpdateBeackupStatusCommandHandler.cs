using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackup;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackupStatus
{
    internal class UpdateBeackupStatusCommandHandler : ICommandHandler<UpdateBeackupStatusCommand, BaseResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateBeackupStatusCommandHandler> _localization;
        public UpdateBeackupStatusCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateBeackupStatusCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(UpdateBeackupStatusCommand request, CancellationToken cancellationToken)
        {
            var beackup = await _unitOfWork.BeackupRepository.GetBeackupAsync(request.beackupId);
            if (beackup is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundBeackup"].Value);
            beackup.UpdateBeackupStatus(request.status);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateBeackupSuccess"].Value);
        }
    }
}
