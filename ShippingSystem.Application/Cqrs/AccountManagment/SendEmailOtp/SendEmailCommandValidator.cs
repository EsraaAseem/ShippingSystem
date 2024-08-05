using FluentValidation;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.SendEmailOtp
{
    internal class SendEmailCommandValidator : AbstractValidator<SendOtpCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(x => x.userEmail).NotEmpty().WithMessage(" Email required");

        }
    }
}
