using Dapper;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ShippingSystemContext _context;
        public EmployeeRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployee(string RequestId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == RequestId);
        }

        public async void PaidDeliveryFees(string representativeId)
        {
            await _context.Database.GetDbConnection().ExecuteAsync("UPDATE DeliveryFees SET IsPaid=1 WHERE RepresentativeId=@representativeId",
                           new { representativeId = representativeId });
        }

        public async void PaidDeliveryFeesBeackup(string representativeId)
        {

            await _context.Database.GetDbConnection().ExecuteAsync("UPDATE DeliveryFees SET IsPaid=1 WHERE RepresentativeId=@representativeId And DeliveringType=@deliveringType",
                           new { representativeId = representativeId, deliveringType=DeliveringType.Beackup });
        }

        public async void PaidDeliveryFeesInvoices(string representativeId)
        {
            await _context.Database.GetDbConnection().ExecuteAsync("UPDATE DeliveryFees SET IsPaid=1 WHERE RepresentativeId=@representativeId And DeliveringType=@deliveringType",
                                       new { representativeId = representativeId, deliveringType = DeliveringType.Invoice });
        }

        public async void PaidDeliveryFeesMovingShipments(string representativeId)
        {
            await _context.Database.GetDbConnection().ExecuteAsync("UPDATE DeliveryFees SET IsPaid=1 WHERE RepresentativeId=@representativeId And DeliveringType=@deliveringType",
                                       new { representativeId = representativeId, deliveringType = DeliveringType.MovingShipments });
        }

        public async void PaidDeliveryFeesShipments(string representativeId)
        {
            await _context.Database.GetDbConnection().ExecuteAsync("UPDATE DeliveryFees SET IsPaid=1 WHERE RepresentativeId=@representativeId And DeliveringType=@deliveringType",
                                       new { representativeId = representativeId, deliveringType = DeliveringType.Shipment });
        }
    }
}
