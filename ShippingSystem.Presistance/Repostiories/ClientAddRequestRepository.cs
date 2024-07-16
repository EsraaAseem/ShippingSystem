using Microsoft.EntityFrameworkCore;
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
    public class ClientAddRequestRepository : Repository<ClientAddRequest>, IClientAddRequestRepository
    {
        private ShippingSystemContext _context;
        public ClientAddRequestRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckClientRequestEmail(string email)
        {
            return _context.ClientRequest.Any(c=>c.Email == email);
        }

        public bool CheckClientRequestUserName(string userName)
        {
            return _context.ClientRequest.Any(c => c.UserName == userName);
        }

       

        public async Task<ClientAddRequest?> GetClientRequest(Guid id)
        {
            return await _context.ClientRequest.FirstOrDefaultAsync(c=>c.Id == id);
        }
    }
}
