using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ShipmentStatusDto
    {
        public int ShipmentStatusId { get; set; }
        public string ShipmentStatusName { get; set; }
        public string ShipmentStatusDescription { get; set; }
        public string ShipmentStatusMessage { get; set; }
    }
}
