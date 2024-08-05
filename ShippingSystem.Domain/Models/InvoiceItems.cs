

using ShippingSystem.Domain.Helper;

namespace ShippingSystem.Domain.Models
{
    public class InvoiceItems:Entity
    {
        public InvoiceItems(Guid id,string productName, string reciverName, 
            string reciverEmail,double shippingPrice,double productsPrice,double totalCost,double netCost ,Guid invoiceId):base(id)
        {
            ProductName = productName;
            ReciverName = reciverName;
            ReciverEmail = reciverEmail;
            ShippingPrice = shippingPrice;
            ProductsPrice = productsPrice;
            NetCost = netCost;
            TotalCost = totalCost;
            InvoiceId = invoiceId;
        }
        
        public string ProductName { get; private set; }
        public string ReciverName { get; private set; }
        public string ReciverEmail { get; private set; }
        public double TotalCost { get; private set; } //NetAccount
        public double ShippingPrice { get; private set; } 
        public double ProductsPrice { get; private set; }
        public double NetCost { get; private set; }
        public Guid InvoiceId { get; private set; }
        public Invoice Invoice { get;  set; }
    }
}
