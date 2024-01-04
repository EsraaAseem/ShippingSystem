using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class EmployeeUpdateDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public string StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
      //  public float Salary { get; set; }
        public int RoleId { get; set; }

    }
}
