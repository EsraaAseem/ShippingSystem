using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Representatives.Commands.UpdateRepresentative
{
    internal class UpdateRepresentativeCommandHandler : ICommandHandler<UpdateRepresentativeCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateRepresentativeCommandHandler> _localization;
        public UpdateRepresentativeCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateRepresentativeCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }


        public async Task<BaseResponse> Handle(UpdateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = await _unitOfWork.RepresentativeRepository.GetRepresentativeAsync(request.representativeId);
            if (representative is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundRepresentative"].Value);
            if (request.email == null || request.userName == null || request.phoneNumber is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["RequiredEmailorPhoneAndUserName"].Value);
            representative.UpdateRepresentative(request.firstName, request.lastName,request.governorate,request.branchName
                ,request.phoneNumber,request.email,request.userName,request.city,request.address);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateRepresentativeSuccess"].Value);
        }
    }
}
