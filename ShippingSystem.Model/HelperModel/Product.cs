using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShippingSystem.Model.HelperModel
{
    [Owned]
    public class Product
    {

        public string ProductName { get; set; }
        public int Amount { get; set; } = 1;
        public double ProductPrice { get; set; }
        public double ProductWeight { get; set; }
    }
}
