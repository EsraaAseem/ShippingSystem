using ShippingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.ShareResponse
{
    internal class InvoiceResponse
    {
        public string  ClientName { get; set; }
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public double InvoiceDeliveryCost { get; set; }
        public double ItemsCost { get; set; }
        public double Total { get; set; }
        public double PayForClient { get; set; }
        public double PayForSystem { get; set; }
    }
}
