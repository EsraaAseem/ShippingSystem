using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly ShippingSystemContext _context;
        public InvoiceRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Invoice ?> GetInvoiceAsync(Guid id)
        {
            return await _context.Invoices.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
