using FluentValidation;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shippings.Commands.UpdateShippingLocation
{
    internal class UpdateShippingLocationValidator : AbstractValidator<UpdateShippingLocationCommand>
    {
        public UpdateShippingLocationValidator()
        {
            RuleFor(x => x.currentLocation).NotEmpty().WithMessage(" location  Reqguired");
            RuleFor(x => x.shippingId).NotEmpty().WithMessage(" shipping Id Reqguired");

        }
    }
}
