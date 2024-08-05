using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class BeackupRepository : Repository<Beackup>, IBeackupRepository
    {
        private ShippingSystemContext _context;
        public BeackupRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Beackup?> GetBeackupAsync(Guid id)
        {
            return await _context.Beackups.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
