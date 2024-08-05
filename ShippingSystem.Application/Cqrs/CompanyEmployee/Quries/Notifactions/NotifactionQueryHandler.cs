using MapsterMapper;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.Notifactions
{
    internal class NotifactionQueryHandler : IQueryHandler<NotifactionQuery, BaseResponse>
    {
        private readonly IEmployeeServiceQuery _employeeService;
        private readonly IMapper _mapper;

        public NotifactionQueryHandler( IEmployeeServiceQuery employeeService,IMapper mapper)
        {
          _employeeService = employeeService; 
           _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(NotifactionQuery request, CancellationToken cancellationToken)
        {
            var notify = await _employeeService.GetNotifactions();
            return await BaseResponse.SuccessResponseWithDataAsync(_mapper.Map<List<Notification>>(notify));
        }
    }
}
