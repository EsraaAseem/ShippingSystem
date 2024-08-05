using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class GovernorateRepository : Repository<Governorate>, IGovernorateRepository
    {

        private ShippingSystemContext _context;
        public GovernorateRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckGovernorate(string name)
        {
            return _context.Governorates.Any(g => g.Name.ToLower() == name.ToLower());
        }

        public async Task<Governorate?> GetGovernorate(Guid id)
        {
            return await _context.Governorates.FindAsync(id);
        }
    }
}
