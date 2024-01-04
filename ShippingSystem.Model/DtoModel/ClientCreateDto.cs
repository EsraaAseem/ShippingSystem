using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShippingSystem.Model.HelperModel;

namespace ShippingSystem.Model.DtoModel
{
    public class ClientCreateDto:Register
    {
        public string companyName { get; set; }
        public IFormFile? Image { get; set; }

        [JsonIgnore]
        public string? Role { get; set; } = "Client";

    }
}
