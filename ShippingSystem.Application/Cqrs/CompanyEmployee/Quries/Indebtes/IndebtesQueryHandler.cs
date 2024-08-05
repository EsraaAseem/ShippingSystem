
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.Indebtes
{
    internal class IndebtesQueryHandler : IQueryHandler<IndebtesQuery, BaseResponse>
    {
        private readonly IEmployeeServiceQuery _employeeService;
        public IndebtesQueryHandler(IEmployeeServiceQuery employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<BaseResponse> Handle(IndebtesQuery request, CancellationToken cancellationToken)
        {
            double shipments = _employeeService.GetIndebtes();
            return await BaseResponse.SuccessResponseWithDataAsync(shipments);
        }
    }
}

