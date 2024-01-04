using ShippingSystem.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class CourierCreateDto:Register
    {
      //  public float Salary { get; set; }
       // [JsonIgnore]
       // public DateTime JobStart { get; set; }= DateTime.Now;
        [JsonIgnore]
        public string Role { get; set; } = "Courier";
    }
}
