using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class InvoiceCreateDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public string ClientId { get; set; }
        [JsonIgnore]
        public double ClientMoney { get; set; }
        [JsonIgnore]
        public double CompanyMoney { get; set; }
        [JsonIgnore]
        public double TotalNetAccount { get; set; }
    }
}
