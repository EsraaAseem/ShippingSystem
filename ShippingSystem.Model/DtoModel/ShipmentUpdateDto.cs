using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.HelperModel;

namespace ShippingSystem.Model.DtoModel
{
    public class ShipmentUpdateDto
    {
        public Guid BackupId { get; set; }
        public string TrackingNumber { get; set; }
        public Reciver Reciver { get; set; }
        public int Shipping { get; set; }
        public DateTime MovedDate { get; set; }
        public DateTime ProccedDate { get; set; }
        public int ShipmentStatusId { get; set; }
      
    }
}
