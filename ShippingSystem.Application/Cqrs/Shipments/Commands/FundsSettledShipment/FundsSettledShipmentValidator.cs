using FluentValidation;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shipments.Commands.FundsSettledShipment
{
    internal class FundsSettledShipmentValidator : AbstractValidator<FundsSettledShipmentCommand>
    {
        public FundsSettledShipmentValidator()
        {
            RuleFor(x => x.deliveryId).NotEmpty().WithMessage(" delivery id Reqguired");
            RuleFor(x => x.deliveryType).NotEmpty().WithMessage(" delivery type Reqguired");
            
        }
    }
}
