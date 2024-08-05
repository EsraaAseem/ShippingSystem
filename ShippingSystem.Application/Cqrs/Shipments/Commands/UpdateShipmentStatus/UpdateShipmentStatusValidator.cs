using FluentValidation;


namespace ShippingSystem.Application.Cqrs.Shipments.Commands.UpdateShipmentStatus
{
    internal class UpdateShipmentStatusValidator : AbstractValidator<UpdateShipmentStatusCommand>
    {
        public UpdateShipmentStatusValidator()
        {
            RuleFor(x => x.status).NotEmpty().WithMessage(" status Reqguired");
            RuleFor(x => x.shipmentId).NotEmpty().WithMessage(" shipment id Reqguired");
            RuleFor(x => x.productsAmounts).NotEmpty().WithMessage(" product amount  required ");
            

        }
    }
}
