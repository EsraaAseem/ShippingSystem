using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ShipmentDto
    {
        public int ShipmentId { get; set; }
        public string TrackingNumber { get; set; }
        public BackUp BackUp { get; set; }
        public List<Product> Products { get; set; }
        public Reciver Reciver { get; set; }
        public Shipping Shipping { get; set; }
        public Client Client { get; set; }
        public double TotalWight { get; set; }
        public double ShippingPrice { get; set; }
        public double ProductTotalPrice { get; set; }
        public double TotalPrice { get; set; }
        public double NetAccount { get; set; }
        public Area Area { get; set; }
        public DateTime MovedDate { get; set; }
        public DateTime ProccedDate { get; set; }
        public ShipmentStatus ShippingStatus { get; set; }
        public string paymentStatus { get; set; }
    }
}
