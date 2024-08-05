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
    internal class RepresentativeRepository : Repository<Representative>, IRepresentativeRepository
    {
        private readonly ShippingSystemContext _context;
        public RepresentativeRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Representative?> GetRepresentativeAsync(string id)
        {
            return await _context.Representatives.FindAsync(id);
        }
    }
}
