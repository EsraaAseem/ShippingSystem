using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;


namespace ShippingSystem.Application.Cqrs.Cities.Commands.AddCity
{
    public record AddCityCommand( string name, string governorateName, double shippingCost, double excessShippingCost,
            double returnShippingCost, double beackupDeliveryCost, double invoiceDeliveryCost,
            double courierShippingCostPercent, double courierInvoiceDeliveryCostPercent,
            double courierBeackupDeliveryCostPercent, double courierShipmentMoveCost):ICommand<BaseResponse>;
}
