
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Helper;
using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Domain.Models
{
    public class Beackup:Entity
    {
        protected Beackup(Guid id,DateTime? startDeliveryTime,DateTime? endDeliveryTime,
            int orderNumber,Beackupstatus status,string clientId,string representativeId,Guid? vehicleId) : base(id)
        {
            StartDeliveryTime = startDeliveryTime;
            EndDeliveryTime = endDeliveryTime;
            OrderNumber = orderNumber;
            Status = status;
            ClientId = clientId;
            RepresentativeId = representativeId;
            VehicleId = vehicleId;

        }

        public DateTime? StartDeliveryTime { get; private set; }
        public DateTime? EndDeliveryTime { get; private set; }
        public DateTime? RecivedTime { get; private set; }
        public int OrderNumber { get; private set; }
        public Beackupstatus Status { get; private set; } = Beackupstatus.Unconfirmed;
        public string? ClientId { get; private set; }
        public Client Client { get; private set; }
        public string? RepresentativeId { get; private set; }
        public Representative Representative { get; private set; }
        public Guid? VehicleId { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public static Beackup CreateBeackup(Guid id, DateTime? startDeliveryTime, DateTime endDeliveryTime,
            int orderNumber, Beackupstatus status, string clientId, string representativeId, Guid vehicleId)
        {
            return new Beackup(id,startDeliveryTime,endDeliveryTime,orderNumber,status,clientId, representativeId,vehicleId);
        }
    }
}
