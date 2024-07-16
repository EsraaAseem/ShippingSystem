using ShippingSystem.Domain.Helper;

namespace ShippingSystem.Domain.Models
{
    public class Governorate:Entity
    {
        private Governorate(Guid id,string name) : base(id)
        {
            Name = name;
        }

        public string Name { get;private set; }
        public static Governorate CreateCovernorate(Guid id,string name)
        {
            return new Governorate(id,name);
        }
    }
}
