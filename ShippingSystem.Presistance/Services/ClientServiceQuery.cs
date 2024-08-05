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
    public class ClientServiceQuery:IClientServiceQuery
    {
        private readonly ShippingSystemContext _context;

        public ClientServiceQuery(ShippingSystemContext context)
        {
            _context = context;
        }

        public async Task<Client?> GetClientAsync(string id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<List<Notification>> GetClientNotifactions(string clientId)
        {
            return await _context.Notifications.Where(n => n.ReciverId == clientId).ToListAsync();
        }
    }
}
