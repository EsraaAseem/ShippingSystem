using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.BaseModel
{
    public class Client:ApplicationUser
    {
        public string CompanyName { get; set; }
        public string Logo { get; set; }


    }
}
