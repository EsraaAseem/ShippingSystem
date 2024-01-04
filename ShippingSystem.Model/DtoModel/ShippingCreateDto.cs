using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.HelperModel;

namespace ShippingSystem.Model.DtoModel
{
    public class ShippingCreateDto
    {
        public string CourierId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
