using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.GetEmployeeProfile
{
    public record EmployeeProfileQuery(string employeeId):IQuery<BaseResponse>;
}
