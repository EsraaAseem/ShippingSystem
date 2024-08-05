using FluentValidation;
using ShippingSystem.Application.Cqrs.Governorates.Commands.AddGovernorate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Governorates.Commands.UpdateCovernorate
{
    internal class UpdateCovernorateValidator : AbstractValidator<UpdateCovernorateCommand>
    {
        public UpdateCovernorateValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage(" name  Reqguired");

        }
    }
}
