using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.BaseModel
{
    public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public double ShippingPrice { get; set; }
        public double ExcessShippingPrice { get; set;}
        public double ReturnShippingPrice { get; set;}
    }
}
