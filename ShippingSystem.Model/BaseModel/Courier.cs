using System;

namespace ShippingSystem.Model.BaseModel
{
    public class Courier:ApplicationUser
    {
        public string ?CourierStatus { get; set; }
        public string? CourierWorkingHours { get; set; }

    }
}
