using ShippingSystem.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Models
{
    public class Shipping : Entity
    {
        private Shipping(Guid id,string representativeId, Guid vehicleId, DateTime startDate,
            string locationFrom, string locationTo):base(id)
        {
            RepresentativeId = representativeId;
            VehicleId = vehicleId;
            StartDate = startDate;
            LocationFrom = locationFrom;
            LocationTo = locationTo;
        }

        public string RepresentativeId { get; set; }
        public Representative Representative { get; set; }
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public string? LocationFrom { get; set; }
        public string? LocationTo { get; set; }
        public string ? CurrentLocation { get; set; }
        public bool IsShipped { get; set; }=false;
        public ReadOnlyCollection<Shipment> Shipments { get;}
        public static Shipping CreateShipping(Guid id, string representativeId, Guid vehicleId, DateTime startDate,
            string locationFrom, string locationTo)
        {
            return new Shipping(id,representativeId,vehicleId,startDate,locationFrom,locationTo);
        }
        public void UpdateShippingStatus()
        {
            IsShipped = true;
        }
        public void UpdateShippingLocation( string currentLocation )
        {
            CurrentLocation = currentLocation;
        }

    }
}
