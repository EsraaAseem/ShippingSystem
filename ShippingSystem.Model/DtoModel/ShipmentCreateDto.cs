using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ShipmentCreateDto
    {
        public Guid?BackupId { get; set; }
        public string TrackingNumber { get; set; }
        public List<Product> Products { get; set; }
        public Reciver Reciver { get; set; }
        public int AreaId { get; set; }
        public int ShipmentStatusId { get; set; }
        public string PaymentStatus { get; set; } = "Pending";

    }
}
