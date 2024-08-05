using FluentValidation;
using ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackupStatus
{
    internal class UpdateBeackupStatusValidator : AbstractValidator<UpdateBeackupStatusCommand>
    {
        public UpdateBeackupStatusValidator()
        {
            RuleFor(x => x.status).NotEmpty().WithMessage(" status Reqguired");
            RuleFor(x => x.beackupId).NotEmpty().WithMessage(" beackup is Reqguired");

        }
    }
}
