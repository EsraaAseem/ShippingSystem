using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ClientUpdateDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public string StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public IFormFile? Image { get; set; }
        [JsonIgnore]
        public string? Logo { get; set; }

    }
}
