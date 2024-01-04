using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.BaseModel
{
    public class CompanyInformation
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
    }
}
