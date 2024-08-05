using FluentValidation;
using ShippingSystem.Application.Cqrs.Authentication.Representatives.RepresentativeRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Representatives.Commands.UpdateRepresentative
{
    internal class UpdateRepresentativeValidator : AbstractValidator<UpdateRepresentativeCommand>
    {
        public UpdateRepresentativeValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage(" Email Reqguired");
            RuleFor(x => x.userName).NotEmpty().WithMessage(" user name Reqguired");
            RuleFor(x => x.lastName).NotEmpty().WithMessage(" last Reqguired");
            RuleFor(x => x.firstName).NotEmpty().WithMessage(" first Reqguired");
            RuleFor(x => x.city).NotEmpty().WithMessage(" city Reqguired");
            RuleFor(x => x.address).NotEmpty().WithMessage(" address Reqguired");

        }
    }
}
