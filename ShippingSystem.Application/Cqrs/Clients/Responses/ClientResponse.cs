using ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse;


namespace ShippingSystem.Application.Cqrs.Clients.Responses
{
    public class ClientResponse:ContactData
    {
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string? Governorate { get; set; }
        public string? City { get; set; }
        public string? Branch { get; set; }
    }
}
