using ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Response
{
    public class EmployeeResponse : ContactData
    {
        public string? NotifactionImage { get; set; }
        public string? NotifactionName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public bool? IsRead { get; set; }
        public DateTime NotificationTime { get; set; }
    }
}
