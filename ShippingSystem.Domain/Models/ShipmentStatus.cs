using ShippingSystem.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Models
{
    public class ShipmentStatus : Entity
    {
        public ShipmentStatus(Guid id,string shipmentStatusName,string shipmentStatusDescription) : base(id)
        {
            ShipmentStatusName = shipmentStatusName;
            ShipmentStatusDescription = shipmentStatusDescription;
        }
        public string ShipmentStatusName { get; private set; }
        public string ?ShipmentStatusDescription { get;private set; }
    }
}
