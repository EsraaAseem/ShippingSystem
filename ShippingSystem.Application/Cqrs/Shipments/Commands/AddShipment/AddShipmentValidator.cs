using FluentValidation;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment
{
    internal class AddShipmentValidator : AbstractValidator<AddShipmentCommand>
    {
        public AddShipmentValidator()
        {
            RuleFor(x => x.shipmentStatusId).NotEmpty().WithMessage(" shipments status id Reqguired");
            RuleFor(x => x.backupId).NotEmpty().WithMessage(" beackup id Reqguired");
            RuleFor(x => x.clientId).NotEmpty().WithMessage(" client id  required Reqguired");
            RuleFor(x => x.cityId).NotEmpty().WithMessage(" city id  Reqguired");
            RuleFor(x => x.reciver).NotEmpty().WithMessage(" reciver Reqguired");
            RuleFor(x => x.products).NotEmpty().WithMessage(" products Reqguired");
            RuleFor(x => x.movedDate).NotEmpty().WithMessage(" move data Reqguired");
            RuleFor(x => x.paymentStatus).NotEmpty().WithMessage(" payment status Reqguired");
            RuleFor(x => x.shipmentTypeId).NotEmpty().WithMessage(" shipment type id Reqguired");

        }
    }
  
}
