using FluentValidation;
using ShippingSystem.Application.Cqrs.Authentication.Representatives.RepresentativeRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping
{
    internal class AddShippingValidator : AbstractValidator<AddShippingCommand>
    {
        public AddShippingValidator()
        {
            RuleFor(x => x.shipmentsIds).NotEmpty().WithMessage(" shipments Reqguired");
            RuleFor(x => x.vehicleId).NotEmpty().WithMessage(" vehicle Reqguired");
            RuleFor(x => x.locationFrom).NotEmpty().WithMessage(" location required Reqguired");
            RuleFor(x => x.locationTo).NotEmpty().WithMessage(" location  Reqguired");
            RuleFor(x => x.representativeId).NotEmpty().WithMessage(" Representative Reqguired");
            RuleFor(x => x.startDate).NotEmpty().WithMessage(" data Reqguired");
          
        }
    }
}
