using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientProfile;
using ShippingSystem.Application.Cqrs.Clients.Responses;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.UpdateEmployeeProfile;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Response;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.GetEmployeeProfile
{
    internal class EmployeeProfileQueryHandler : IQueryHandler<EmployeeProfileQuery, BaseResponse>
    {

        private readonly IEmployeeServiceQuery _employeeService;
        private readonly IMapper _mapper;
        public EmployeeProfileQueryHandler(IEmployeeServiceQuery employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(EmployeeProfileQuery request, CancellationToken cancellationToken)
        {
            var client = await _employeeService.GetEmployee(request.employeeId);
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<EmployeeResponse>(client));
        }
      
    }
}
