

namespace ShippingSystem.Model.BaseModel
{
    public class Employee:ApplicationUser
    {
        public string Role { get; set; }
        public float Salary { get; set; }
    }
}
