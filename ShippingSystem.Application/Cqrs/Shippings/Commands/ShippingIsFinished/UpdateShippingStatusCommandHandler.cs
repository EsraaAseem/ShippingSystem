using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Shippings.Commands.ShippingIsFinished
{
    internal class UpdateShippingStatusCommandHandler : ICommandHandler<UpdateShippingStatusCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateShippingStatusCommandHandler> _localization;
        public UpdateShippingStatusCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateShippingStatusCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(UpdateShippingStatusCommand request, CancellationToken cancellationToken)
        {
            var shipping = await _unitOfWork.ShippingRepository.GetShipping(request.shippingId);
            if (shipping is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundShip"].Value);
            shipping.UpdateShippingStatus();
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateShippingSuccess"].Value);
        }
    }
}
