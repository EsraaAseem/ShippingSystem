using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.Enums
{
    public enum GeneralShipmentStatus:byte
    {
        Unknown = 0,
        FundsSettled,
        InvoiceCreated
    }
}
