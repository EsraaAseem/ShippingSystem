using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Helper;


namespace ShippingSystem.Domain.Models
{
    public class ShipmentStatus : Entity
    {
        public ShipmentStatus(Guid id,ShipmentStatuses shipmentStatusName,string shipmentStatusDescription) : base(id)
        {
            ShipmentStatusName = shipmentStatusName;
            ShipmentStatusDescription = shipmentStatusDescription;
        }
        public ShipmentStatuses ShipmentStatusName { get; private set; } = ShipmentStatuses.UnConfirmed;
        public string ?ShipmentStatusDescription { get;private set; }
    }
}
