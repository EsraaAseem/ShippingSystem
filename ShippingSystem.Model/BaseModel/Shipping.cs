using ShippingSystem.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.BaseModel
{
    public class Shipping
    {
        public int ShippingId { get; set; }
        public string CourierId {get; set;}
        public Courier Courier {get; set;}
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public string CurrentLocation { get; set; }
    }
}
