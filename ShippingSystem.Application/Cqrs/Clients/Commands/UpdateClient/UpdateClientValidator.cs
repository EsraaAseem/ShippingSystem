using FluentValidation;
using ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Clients.Commands.UpdateClient
{
    internal class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage(" Email Reqguired");
            RuleFor(x => x.userName).NotEmpty().WithMessage(" user name Reqguired");
            RuleFor(x => x.name).NotEmpty().WithMessage(" name Reqguired");
            RuleFor(x => x.companyName).NotEmpty().WithMessage(" company name Reqguired");
            RuleFor(x => x.logo).NotEmpty().WithMessage(" logo Reqguired");
            RuleFor(x => x.branch).NotEmpty().WithMessage(" branch Reqguired");
            RuleFor(x => x.Covernorate).NotEmpty().WithMessage(" Governorate Reqguired");
            RuleFor(x => x.city).NotEmpty().WithMessage(" city Reqguired");
            RuleFor(x => x.address).NotEmpty().WithMessage(" address Reqguired");

        }
    }
}
