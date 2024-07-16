
using ShippingSystem.Domain.Helper;

namespace ShippingSystem.Domain.Models
{
    public class Vehicle:Entity
    {
        private Vehicle(Guid id, string name, string? description):base(id)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string? Description { get; private set; }
        public static Vehicle CreateVehicle(Guid id, string name, string? description)
        {
            return new Vehicle(id, name, description);
        }
    }
}
