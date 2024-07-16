using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse
{
    public class ContactData
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public bool PhoneConfirmed { get; set; } = false;
    }
}
