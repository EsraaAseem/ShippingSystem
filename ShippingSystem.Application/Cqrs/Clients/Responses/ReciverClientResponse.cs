using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Clients.Responses
{
    public class ReciverClientResponse
    {
        public string Name { get;  set; }
        public string City { get;  set; }
        public string StreetAddress { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
    }
}
