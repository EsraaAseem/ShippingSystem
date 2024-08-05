using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class ShippingRepository : Repository<Shipping>, IShippingRepository
    {
        private readonly ShippingSystemContext _context;
        public ShippingRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Shipping?> GetShipping(Guid shippingId)
        {
            return await _context.Shippings.FirstOrDefaultAsync(s=>s.Id==shippingId);
        }
    }
      
}
