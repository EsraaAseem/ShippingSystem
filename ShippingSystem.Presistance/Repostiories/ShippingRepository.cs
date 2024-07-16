using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Repostiories
{
    public class ShippingRepository : Repository<Shipping>, IShippingRepository
    {
        public ShippingRepository(ShippingSystemContext context) : base(context)
        {
        }
    }
      
}
