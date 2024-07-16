
using ShippingSystem.Domain.Helper;

namespace ShippingSystem.Domain.Models
{
    public class City:Entity
    {
        private City(Guid id,string name, string governorateName, double shippingCost, double excessShippingCost,
            double returnShippingCost, double? beackupDeliveryCost, double? invoiceDeliveryCost,
            double? courierShippingCostPercent, double? courierInvoiceDeliveryCostPercent,
            double? courierBeackupDeliveryCostPercent, double? courierShipmentMoveCost):base(id)
        {
            Name = name;
            GovernorateName = governorateName;
            ShippingCost = shippingCost;
            ExcessShippingCost = excessShippingCost;
            ReturnShippingCost = returnShippingCost;
            BeackupDeliveryCost = beackupDeliveryCost;
            InvoiceDeliveryCost = invoiceDeliveryCost;
            CourierShippingCostPercent = courierShippingCostPercent;
            CourierInvoiceDeliveryCostPercent = courierInvoiceDeliveryCostPercent;
            CourierBeackupDeliveryCostPercent = courierBeackupDeliveryCostPercent;
            CourierShipmentMoveCost = courierShipmentMoveCost;
        }

        public string Name { get; private set; }
        public string GovernorateName { get; private set; }
        public double ShippingCost { get; private set; }
        public double ExcessShippingCost { get; private set; }
        public double ReturnShippingCost { get; private set; }
        public double? BeackupDeliveryCost { get; private set; }
        public double? InvoiceDeliveryCost { get; private set; }
        public double? CourierShippingCostPercent { get; private set; }
        public double? CourierInvoiceDeliveryCostPercent { get; private set; }
        public double? CourierBeackupDeliveryCostPercent { get; private set; }
        public double? CourierShipmentMoveCost { get; private set; }
        public static City CreateCity(Guid id, string name, string governorateName, double shippingCost, double excessShippingCost,
            double returnShippingCost, double? beackupDeliveryCost, double? invoiceDeliveryCost,
            double? courierShippingCostPercent, double? courierInvoiceDeliveryCostPercent,
            double? courierBeackupDeliveryCostPercent, double? courierShipmentMoveCost)
        {
            return new City(id,name,governorateName,shippingCost,excessShippingCost,returnShippingCost,
                beackupDeliveryCost,invoiceDeliveryCost,courierShippingCostPercent,
                courierInvoiceDeliveryCostPercent,courierBeackupDeliveryCostPercent,courierShipmentMoveCost);
        }
    }
}
