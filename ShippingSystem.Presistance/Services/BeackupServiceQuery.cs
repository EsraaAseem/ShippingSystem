using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Services
{
    public class BeackupServiceQuery : IBeackupServiceQuery
    {
        private readonly ShippingSystemContext _context;

        public BeackupServiceQuery( ShippingSystemContext context)
        {
            _context = context;
        }

        public IQueryable<Beackup> BeackupClientRequests(string clientId)
        {
            return _context.Beackups.Where(x=> x.ClientId == clientId && x.Status==Beackupstatus.Unconfirmed);
        }

        public IQueryable<Beackup> BeackupClientShipping(string clientId)
        {
            return _context.Beackups.Where(x => x.ClientId == clientId && (x.Status != Beackupstatus.Unconfirmed
            || x.Status != Beackupstatus.Canceled|| x.Status != Beackupstatus.Approved));
        }

        public IQueryable<Beackup> BeackupRequests()
        {
            return _context.Beackups.Where(x => x.Status == Beackupstatus.Unconfirmed);
        }
        public async Task<Beackup?> GetBeackup(Guid id)
        {
            return await _context.Beackups.AsSplitQuery().Include(b=>b.Client).Include(b=>b.Representative).Include(b=>b.Vehicle).FirstOrDefaultAsync(b=>b.Id==id);
        }

        public IQueryable<Beackup> BeackupsShipping()
        {
            return _context.Beackups.Where(x =>(x.Status != Beackupstatus.Unconfirmed
                        || x.Status != Beackupstatus.Canceled || x.Status != Beackupstatus.Approved));
        }
    }
}
