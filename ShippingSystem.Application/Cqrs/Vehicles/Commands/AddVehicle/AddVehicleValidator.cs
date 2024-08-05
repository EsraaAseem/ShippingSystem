using FluentValidation;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle
{
    internal class AddVehicleValidator : AbstractValidator<AddVehicleCommand>
    {
        public AddVehicleValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage(" name Reqguired");
            
        }
    }
}
