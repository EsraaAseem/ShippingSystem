using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;
using System.Xml.Linq;

namespace ShippingSystem.Application.Cqrs.Cities.Commands.UpdateCity
{
    internal class UpdateCityCommandHandler : ICommandHandler<UpdateCityCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWrok;
        private readonly IStringLocalizer<UpdateCityCommandHandler> _localization;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<UpdateCityCommandHandler> localization)
        {
            _unitOfWrok = unitOfWork;
            _localization = localization;
        }


        public async Task<BaseResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWrok.CityRepository.GetCityAsync(request.name);
            if (city is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundCity"]);
            city.UpdateCity(request.name, request.governorateName, request.shippingCost, request.excessShippingCost,
             request.returnShippingCost, request.beackupDeliveryCost, request.invoiceDeliveryCost,
            request.courierShippingCostPercent, request.courierInvoiceDeliveryCostPercent,
             request.courierBeackupDeliveryCostPercent, request.courierShipmentMoveCost);
            await _unitOfWrok.SaveChangesAsync(cancellationToken);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateCitySuccess"].Value);

        }
    }
}
