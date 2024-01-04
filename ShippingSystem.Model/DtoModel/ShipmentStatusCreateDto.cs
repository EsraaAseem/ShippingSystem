using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class ShipmentStatusCreateDto
    {
        [Required]
        public string ShipmentStatusName { get; set; }
        public string ShipmentStatusDescription { get; set; }
        public string ShipmentStatusMessage { get; set; }
    }
}
