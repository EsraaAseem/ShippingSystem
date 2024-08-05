using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Governorates.Commands.AddGovernorate;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System.Xml.Linq;

namespace ShippingSystem.Application.Cqrs.Cities.Commands.AddCity
{
    internal class AddCityCommandHandler : ICommandHandler<AddCityCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddCityCommandHandler> _localization;
        public AddCityCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddCityCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            if (_unitOfWork.CityRepository.CheckCity(request.governorateName, request.name))
                return await BaseResponse.BadRequestResponsAsync(_localization["CityAlreadyExist"].Value);
            var city = City.CreateCity(Guid.NewGuid(),request.name,request.governorateName,request.shippingCost,
                request.excessShippingCost,request.returnShippingCost,request.beackupDeliveryCost,
                request.invoiceDeliveryCost,request.courierShippingCostPercent,
                request.courierInvoiceDeliveryCostPercent,request.courierBeackupDeliveryCostPercent,request.courierShipmentMoveCost);

            await _unitOfWork.CityRepository.Add(city);
            await _unitOfWork.SaveChangesAsync();
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["CreateCitySuccess"].Value);
        }
    }
}
