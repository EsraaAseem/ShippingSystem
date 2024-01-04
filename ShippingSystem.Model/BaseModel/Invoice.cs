using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.BaseModel
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }

        public string ClientId { get; set; } 
        public Client Client { get; set; }
        public List<Shipment> Shipments { get; set; } 
        public double ClientMoney { get; set; }
        public double CompanyMoney { get; set; }
        public double TotalNetAccount { get; set; }
    }
}
