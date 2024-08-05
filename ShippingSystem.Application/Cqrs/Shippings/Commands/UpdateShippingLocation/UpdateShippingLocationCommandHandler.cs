using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shippings.Commands.UpdateShippingLocation
{
    internal class UpdateShippingLocationCommandHandler : ICommandHandler<UpdateShippingLocationCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateShippingLocationCommandHandler> _localization;
        public UpdateShippingLocationCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateShippingLocationCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(UpdateShippingLocationCommand request, CancellationToken cancellationToken)
        {
            var shipping = await _unitOfWork.ShippingRepository.GetShipping(request.shippingId);
            if (shipping is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundShip"].Value);
            shipping.UpdateShippingLocation(request.currentLocation);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateShippingSuccess"].Value);
        }
    }
}
