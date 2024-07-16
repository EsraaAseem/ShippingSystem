using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Authentication.Employees.EmployeeRegister
{
    public record EmployeeRegCommand(string email, string userName,string pemissionName,
        string password,
        string firstName,
        string lastName,
        string? phoneNumber,
        string address,
        string branchName, string city) : ICommand<BaseResponse>;
}
