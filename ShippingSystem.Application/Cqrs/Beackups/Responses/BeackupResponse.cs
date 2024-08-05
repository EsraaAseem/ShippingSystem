using ShippingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Beackups.Responses
{
    public class BeackupResponse
    {
        public int orderNumber { get; set; }
        public DateTime ? OrderProcessData { get; set; }
        public string ClientName { get; set; }
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public string Status { get; set; }
        public string VehicleName { get; set; }

    }
}
