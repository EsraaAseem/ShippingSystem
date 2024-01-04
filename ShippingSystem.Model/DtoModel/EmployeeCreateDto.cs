using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.HelperModel;
using ShippingSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class EmployeeCreateDto:Register
    {
        public string Role { get; set; } = Roles.Role_Customers_Service;
   //     public float salary { get; set; }

    }
}
