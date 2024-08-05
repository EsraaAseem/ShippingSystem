using ShippingSystem.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ShippingSystem.Domain.Models
{
    public class Invoice:Entity
    {
        private Invoice(Guid id,string clientId,string? representativeId, double invoiceDeliveryCost,double itemsCost):base(id)
        {
            ClientId = clientId;
            RepresentativeId = representativeId;
            InvoiceDeliveryCost = invoiceDeliveryCost;
            ItemsCost = itemsCost;
        }
        public string ClientId { get; private set; }
        public Client Client { get; set; }
        public string? RepresentativeId { get; private set; }
        public Representative Representative { get; private set; }
        public double InvoiceDeliveryCost { get; private set; }
        public IReadOnlyCollection<InvoiceItems> Items { get; set; }
        public double ItemsCost { get; private set; }
        public double Total => ( ItemsCost + InvoiceDeliveryCost);
        public double PayForClient => Total > 0 ? Total : 0;
        public double PayForSystem => Total < 0 ? Total : 0;
        public static Invoice  CreateInvoice(Guid id, string clientId, string? representativeId,double invoiceDeliveryCost,double itemsCost)
        {
            return new Invoice(id, clientId, representativeId, invoiceDeliveryCost,itemsCost);
        }
    }
}
