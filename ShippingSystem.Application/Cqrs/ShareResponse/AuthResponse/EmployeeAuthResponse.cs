using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse
{
    public class EmployeeAuthResponse:DataAuthResponse
    {
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string? Governorate { get; private set; }
        public string? BranchName { get; private set; }
    }
}
