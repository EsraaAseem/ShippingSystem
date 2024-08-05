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
    internal class DeliveryFeesRepository : Repository<DeliveryFees>, IDeliveryFeesRepository
    {

        private ShippingSystemContext _context;
        public DeliveryFeesRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

    }
}
