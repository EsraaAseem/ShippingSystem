using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using ShippingSystem.Application.Cqrs.Clients.Commands.UpdateClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.UpdateEmployeeProfile
{
    internal class UpdateEmployeeProfileCommandHandler : ICommandHandler<UpdateEmployeeProfileCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IStringLocalizer<UpdateEmployeeProfileCommandHandler> _localization;
        public UpdateEmployeeProfileCommandHandler(IUnitOfWork unitOfWork, IMediaService mediaService, IStringLocalizer<UpdateEmployeeProfileCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(UpdateEmployeeProfileCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetEmployee(request.employeeId);
            if (employee is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundEmployee"].Value);
            if (request.email == null || request.userName == null||request.phoneNumber is { })
                return await BaseResponse.NotFoundResponsAsync(_localization["RequiredEmailAndUserName"].Value);

            employee.UpdateEmployee(request.firstName, request.lastName, request.branch, request.phoneNumber, request.email,
                request.userName, request.city, request.address);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateEmployeeSuccess"].Value);
        }
    }
}
