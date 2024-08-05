using FluentValidation;
using ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackup
{
    internal class UpdateBeackupValidator : AbstractValidator<UpdateBeackupCommand>
    {
        public UpdateBeackupValidator()
        {
            RuleFor(x => x.vehicleId).NotEmpty().WithMessage(" vehicle Reqguired");
            RuleFor(x => x.representativeId).NotEmpty().WithMessage(" Representative is Reqguired");
            RuleFor(x => x.orderNumber).NotEmpty().WithMessage(" order number  Reqguired");

        }
    }
    
}
