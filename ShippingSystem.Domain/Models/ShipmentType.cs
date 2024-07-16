using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Models
{
    public class ShipmentType
    {
        public ShipmentType(int id, string name, int numDays, double extreShippingCost)
        {
            Id = id;
            Name = name;
            NumDays = numDays;
            ExtreShippingCost = extreShippingCost;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int NumDays { get; private set; }
        public double ExtreShippingCost { get; private set; }   
    }
}
