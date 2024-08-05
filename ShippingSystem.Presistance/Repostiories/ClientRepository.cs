using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Repostiories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ShippingSystemContext _context;
        public ClientRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Client?> GetClientAsync(string clientId)
        {
            return await  _context.Clients.FirstOrDefaultAsync(c=>c.Id == clientId);
        }
    }
}
