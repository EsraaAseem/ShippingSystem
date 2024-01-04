using ShippingSystem.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Model.DtoModel
{
    public class BackupDto
    {
        public Guid BackupId { get; set; }
        public DateTime FromShippingTime { get; set; }
        public DateTime ToShippingTime { get; set; }
        public DateTime RecivedTime { get; set; }
        public int ShippingNumber { get; set; }
        public string BackupStatus { get; set; }
        public Client Client { get; set; }
        public Courier Courier { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
