using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Cities.Response.CitiesResponse;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShippingSystem.Application.Cqrs.Cities.Queries.GetCities
{
    internal class CitiesQueryHandler : IQueryHandler<CitiesQuery, BaseResponse>
    {
        private readonly ICityQueryService _cityService;
        public CitiesQueryHandler(ICityQueryService cityService)
        {
            _cityService = cityService;
        }

        public async Task<BaseResponse> Handle(CitiesQuery request, CancellationToken cancellationToken)
        {
            var response = _cityService.GetCities().Select(c => new CityResponse
            {
                Name=c.Name,
                GovernorateName=c.GovernorateName,
                ShippingCost=c.ShippingCost,
                ExcessShippingCost = c.ExcessShippingCost,
                ReturnShippingCost=c.ReturnShippingCost,
                BeackupDeliveryCost = c.BeackupDeliveryCost,
                InvoiceDeliveryCost=c.InvoiceDeliveryCost,
                CourierShippingCostPercent = c.CourierShippingCostPercent,
                CourierInvoiceDeliveryCostPercent = c.CourierInvoiceDeliveryCostPercent,
                CourierBeackupDeliveryCostPercent = c.CourierBeackupDeliveryCostPercent,
                CourierShipmentMoveCost = c.CourierShipmentMoveCost

            });
            return await BaseResponse.SuccessResponseWithDataAsync(response);
        }
    }
}
