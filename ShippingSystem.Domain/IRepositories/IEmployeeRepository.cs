using ShippingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.IRepositories
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        void PaidDeliveryFeesBeackup(string representativeId);
        void PaidDeliveryFeesInvoices(string representativeId);
        void PaidDeliveryFeesMovingShipments(string representativeId);
        void PaidDeliveryFeesShipments(string representativeId);
        void PaidDeliveryFees(string representativeId);
        Task<Employee> GetEmployee(string RequestId);



    }
}
