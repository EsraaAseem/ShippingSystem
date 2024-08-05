using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment
{
    internal class AddShipmentByExcelValidator : AbstractValidator<AddShipmentByExcelCommand>
    {
        public AddShipmentByExcelValidator()
        {
            RuleFor(x => x.file).NotEmpty().WithMessage(" File Reqguired");

        }
    }
}

