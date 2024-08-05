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
    public class InoiceServiceQuery : IInvoiceServiceQuery
    {
        private readonly ShippingSystemContext _context;
        public InoiceServiceQuery(ShippingSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetInvoices(string? id)
        {
            if(id ==null)
               return await _context.Invoices.Include(i=>i.Client).Include(i=>i.Representative).ToListAsync();
            return await _context.Invoices.Include(i => i.Client).Include(i => i.Representative).Where(i=>i.ClientId==id).ToListAsync();

        }
    }
}
