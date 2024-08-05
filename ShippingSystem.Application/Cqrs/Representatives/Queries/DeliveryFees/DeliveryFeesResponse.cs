using ShippingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Representatives.Queries.DeliveryFees
{
    internal class DeliveryFeesResponse
    {
        public DeliveringType DeliveringType { get; set; }
        public double DeliveringCost { get; private set; }
        public double DeliveringRepresentativePrecent { get; private set; }
        public double DeleiveringRepresentativePrice { get; private set; }
        public bool IsPaid { get; set; }
    }
}
