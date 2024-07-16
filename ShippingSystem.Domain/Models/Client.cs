
namespace ShippingSystem.Domain.Models
{
    public class Client:AppUser
    {
        public string CompanyName { get; private set; }
        public string Logo { get; private set; }
        public string? Governorate { get; private set; }
        public string? Branch { get; private set; }

       // public IReadOnlyCollection<City>? Cities { get; private set; }

    }
}
