using FluentValidation;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.CheckOtp
{
    internal class CheckOtpCommandValidator : AbstractValidator<CheckOtpCommand>
    {
        public CheckOtpCommandValidator()
        {
            RuleFor(x => x.otp).NotEmpty().WithMessage("otp is Required");
        }
    }
}
