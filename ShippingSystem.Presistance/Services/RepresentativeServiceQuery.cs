using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;


namespace ShippingSystem.Presistance.Services
{
    internal class RepresentativeServiceQuery:IRepresentativeServiceQuery
    {
        private readonly ShippingSystemContext _context;
        public RepresentativeServiceQuery(ShippingSystemContext context) 
        {
            _context = context;
        }

        public async Task<Representative?> GetRepresentative(string id)
        {
            return await _context.Representatives.FindAsync(id);
        }
        public async Task<List<Notification>> GetClientNotifactions(string representativeId)
        {
            return await _context.Notifications.Where(n => n.ReciverId == representativeId).ToListAsync();
        }

        public async Task<List<DeliveryFees>> RepresentativeDeliveryFees(string representativeId)
        {
            return await _context.DeliveryFees.Where(d=>d.RepresentativeId== representativeId).ToListAsync();
        }

        public  double RepresentativeIndebtes(string representativeId)
        {
            return  _context.DeliveryFees.Where(d => d.RepresentativeId == representativeId).Sum(d => d.DeleiveringRepresentativePrice);
        }
    }
}
