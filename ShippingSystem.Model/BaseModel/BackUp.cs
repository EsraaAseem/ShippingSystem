using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Model.BaseModel
{
    public class BackUp
    {
        [Key]
        public Guid BackupId { get; set; }
        public DateTime FromShippingTime { get; set; }
        public DateTime ToShippingTime { get; set; }
        public DateTime RecivedTime { get; set; }
        public int ShippingNumber { get; set; }
        public string BackupStatus { get; set; }
        public string? ClientId { get; set; }
        public Client Client { get; set; }
        public string? CourierId { get; set; }
        public Courier Courier { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
