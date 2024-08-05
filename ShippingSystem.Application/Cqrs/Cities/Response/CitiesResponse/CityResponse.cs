

namespace ShippingSystem.Application.Cqrs.Cities.Response.CitiesResponse
{
    internal class CityResponse
    {
        public string Name { get; set; }
        public string GovernorateName { get; set; }
        public double ShippingCost { get; set; }
        public double ExcessShippingCost { get; set; }
        public double ReturnShippingCost { get; set; }
        public double BeackupDeliveryCost { get; set; }
        public double InvoiceDeliveryCost { get; set; }
        public double CourierShippingCostPercent { get; set; }
        public double CourierInvoiceDeliveryCostPercent { get; set; }
        public double CourierBeackupDeliveryCostPercent { get; set; }
        public double CourierShipmentMoveCost { get; set; }
    }
}
