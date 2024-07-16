using ShippingSystem.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Models
{
    public class Invoice:Entity
    {
        protected Invoice(Guid id) : base(id)
        {
        }
        public string ClientId { get; private set; }
        public double Toatl { get; private set; }

        public Client Client { get; set; }
        public List<Shipment>? Shipments { get; set; }
    }
}
