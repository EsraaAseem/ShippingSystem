using FluentValidation;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Authentication.Employees.EmployeeRegister
{
    internal class EmployeeRegValidator : AbstractValidator<EmployeeRegCommand>
    {
        public EmployeeRegValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage(" Email Reqguired");
            RuleFor(x => x.address).NotEmpty().WithMessage(" address Reqguired");
            RuleFor(x => x.city).NotEmpty().WithMessage(" city Reqguired");
            RuleFor(x => x.branchName).NotEmpty().WithMessage(" branch name Reqguired");
            RuleFor(x => x.lastName).NotEmpty().WithMessage(" last name Reqguired");
            RuleFor(x => x.firstName).NotEmpty().WithMessage(" first name Reqguired");
            RuleFor(x => x.password).NotEmpty().WithMessage(" password Reqguired");
            RuleFor(x => x.pemissionName).NotEmpty().WithMessage(" permission name Reqguired");
            RuleFor(x => x.userName).NotEmpty().WithMessage(" user name Reqguired");
        }
    }
}
