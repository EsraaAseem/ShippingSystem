using FluentValidation;
using ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Cities.Commands.AddCity
{
    internal class AddCityValidator : AbstractValidator<AddCityCommand>
    {
        public AddCityValidator()
        {
            RuleFor(x => x.shippingCost).NotEmpty().WithMessage(" shipping Cost Reqguired");
            RuleFor(x => x.beackupDeliveryCost).NotEmpty().WithMessage(" beackup Delivery Cost is Reqguired");
            RuleFor(x => x.invoiceDeliveryCost).NotEmpty().WithMessage(" invoice Delivery Cost  Reqguired");
            RuleFor(x => x.courierBeackupDeliveryCostPercent).NotEmpty().WithMessage("courier Beackup Delivery Cost Percent  Reqguired");
            RuleFor(x => x.courierInvoiceDeliveryCostPercent).NotEmpty().WithMessage("courier Invoice Delivery Cost Percent  Reqguired");
            RuleFor(x => x.courierShipmentMoveCost).NotEmpty().WithMessage("courier Shipment Move Cost Reqguired");
            RuleFor(x => x.courierShippingCostPercent).NotEmpty().WithMessage("courier Shipping Cost Percent Reqguired");
            RuleFor(x => x.returnShippingCost).NotEmpty().WithMessage("return Shipping Cost Reqguired");
            RuleFor(x => x.excessShippingCost).NotEmpty().WithMessage(" excess Shipping Cost Reqguired");
            RuleFor(x => x.governorateName).NotEmpty().WithMessage("governorator  Reqguired");
            RuleFor(x => x.name).NotEmpty().WithMessage(" name  Reqguired");


        }

    }
}
