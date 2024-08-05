using ShippingSystem.Domain.Models;
using System;


namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IEmployeeServiceQuery
    {

      Task<Employee> GetEmployee(string employeeId);
        double GetIndebtness();
        double GetIndebtes();
        Task<List<Notification>> GetNotifactions();

    }
}
