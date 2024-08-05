using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using ShippingSystem.Presistance.Specifications;

namespace ShippingSystem.Presistance.Services
{
    public class EmployeeServiceQuery:IEmployeeServiceQuery
    {
        private readonly ShippingSystemContext _context;
        public EmployeeServiceQuery( ShippingSystemContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployee(string employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public double GetIndebtes()
        {
          return Math.Abs(_context.Shipments.Where(s => s.NetAccount() < 0).Sum(s => s.NetAccount()));

        }
        public double GetIndebtness()
        {
            return _context.Shipments.Where(s => s.NetAccount() > 0).Sum(s => s.NetAccount());

        }

        public async Task<List<Notification>> GetNotifactions()
        {
            return await _context.Notifications.ToListAsync();
        }

        private IQueryable<Shipment> ApplySpecification(Specification<Shipment> specification)
        {
            return SpecificationEvaluator.GetQuery(_context.Set<Shipment>(), specification);
        }
    }
}
