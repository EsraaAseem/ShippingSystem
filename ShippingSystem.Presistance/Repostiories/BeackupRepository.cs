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
    public class BeackupRepository : Repository<Beackup>, IBeackupRepository
    {
        private ShippingSystemContext _context;
        public BeackupRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
