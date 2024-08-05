using FluentValidation;
using ShippingSystem.Application.Cqrs.Cities.Commands.AddCity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Governorates.Commands.AddGovernorate
{
    internal class AddGovernorateValidator : AbstractValidator<AddGovernorateCommand>
    {
        public AddGovernorateValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage(" name  Reqguired");

        }
    }
}
