using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse
{
    public class DataAuthResponse
    {
      

        public bool IsAuthenticated { get; set; }
        public ContactData? ConnectionData { get; set; }
        public string ?Id { get; set; }
        public string? UserName { get; set; }
        public string Role { get; set; }
        public AuthData TokensData { get; set; } = new();
        public List<string>? Permissions { get; set; }

    }
}
