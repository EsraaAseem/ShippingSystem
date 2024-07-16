

namespace ShippingSystem.Domain.Models
{
    public class Company
    {
        public int CompanyId { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyPhone { get; private set; }
        public string City { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Logo { get; private set; }
        public string? Governorate { get; private set; }

    }
}
