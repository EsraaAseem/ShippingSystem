using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.Cities.Commands.UpdateCity
{
    public record UpdateCityCommand(string name, string governorateName, double shippingCost, double excessShippingCost,
            double returnShippingCost, double beackupDeliveryCost, double invoiceDeliveryCost,
            double courierShippingCostPercent, double courierInvoiceDeliveryCostPercent,
            double courierBeackupDeliveryCostPercent, double courierShipmentMoveCost) :ICommand<BaseResponse>;
}
