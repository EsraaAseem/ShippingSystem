using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ShippingDto
    {
        public string CourierId { get; set; }
        public Courier Courier { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishingDate { get; set; }
    }
}
