using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Models;
using System.Linq.Expressions;

namespace ShippingSystem.Presistance.Specifications
{
    public class ShipmentSpecifaction : Specification<Shipment>
    {
        // public delegate bool shipmentCondation(Shipment shipment);
        //  public ShipmentSpecifaction(shipmentCondation condation) : base(shipment=>condation(shipment) )
        public ShipmentSpecifaction(Expression<Func<Shipment, bool>> criteria)
         : base(criteria)
        {
            AddInclude(s => s.ShipmentType);
            AddInclude(s => s.ShippmentStatus);
            AddInclude(s => s.City);
        }
    }
}/*
   public ShipmentShippedSpecifaction(string clientId) : base(ship=>ship.ClientId==clientId&&
        ship.Shipping.IsShipped ==true&&ship.GeneralStatus!=GeneralShipmentStatus.InvoiceCreated)
        {
            AddInclude(s => s.ShipmentType);
            AddInclude(s => s.ShippmentStatus);
            AddInclude(s => s.City);
        }
  */
