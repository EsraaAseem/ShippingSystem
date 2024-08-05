using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Services
{
    internal class GovernorateServiceQuery:IGovernorateServiceQuery
    {
        private readonly ShippingSystemContext _context;
        public GovernorateServiceQuery(ShippingSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Governorate>> GetGovernorates()
        {
            return await _context.Governorates.ToListAsync();
        }

        public async Task<Governorate?> GetGovernorate(Guid id)
        {
            return await _context.Governorates.FindAsync(id);
        }
    }
}
