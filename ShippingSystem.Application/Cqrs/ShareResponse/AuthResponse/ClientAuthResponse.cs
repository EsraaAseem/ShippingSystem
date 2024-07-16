

namespace ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse
{
    public class ClientAuthResponse:DataAuthResponse
    {
        public string CompanyName { get; private set; }
        public string Logo { get; private set; }
        public string? Governorate { get; private set; }
        public string? City { get; private set; }
        public string? Branch { get; private set; }
    }
}
