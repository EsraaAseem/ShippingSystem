using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Helper;

namespace ShippingSystem.Domain.Models
{
    public class DeliveryFees : Entity
    {
        private DeliveryFees(Guid id,string representativeId,Guid deliveredId, DeliveringType deliveringType, double deliveringCost, double deliveringRepresentativePrecent, 
            double deleiveringRepresentativePrice) : base(id)
        {
            DeliveredId = deliveredId;
            DeliveringType = deliveringType;
            DeliveringCost = deliveringCost;
            RepresentativeId = representativeId;
            DeliveringRepresentativePrecent = deliveringRepresentativePrecent;
            DeleiveringRepresentativePrice = deleiveringRepresentativePrice;
        }

      
        public Guid DeliveredId { get; private set; }
        public string RepresentativeId { get; private set; }
        public Representative Representative { get; private set; }
        public DeliveringType DeliveringType { get; private set; } = DeliveringType.Shipment;
        public double DeliveringCost { get; private set; } 
        public double DeliveringRepresentativePrecent { get; private set; }
        public double DeleiveringRepresentativePrice { get; private set; }
        public bool IsPaid { get; private set; }=false;
        public static DeliveryFees CreateDeliveryFees(Guid id,string RepresentativeId, Guid deliveredId, DeliveringType deliveringType, double deliveringCost, double deliveringRepresentativePrecent,
            double deleiveringRepresentativePrice)
        {
            return new DeliveryFees(id, RepresentativeId, deliveredId, deliveringType, deliveringCost,deliveringRepresentativePrecent, deleiveringRepresentativePrice);
        }
    }
}
