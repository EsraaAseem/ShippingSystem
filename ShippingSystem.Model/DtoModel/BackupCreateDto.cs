using ShippingSystem.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class BackupCreateDto
    {
        
        public DateTime FromShippingTime { get; set; }
        public DateTime ToShippingTime { get; set; }
        public int ShippingNumber { get; set; }
        public string BackupStatus { get; set; }
        public string? ClientId { get; set; }
        public string? CourierId { get; set; }
        public int? VehicleId { get; set; }
    }
}
