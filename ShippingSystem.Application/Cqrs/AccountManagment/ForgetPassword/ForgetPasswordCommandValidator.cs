using FluentValidation;
using ShippingSystem.Application.Cqrs.AccountManagment.ForgetPassword;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail
{
    internal class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordCommandValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage(" Email guired");
            RuleFor(x => x.newPassword).NotEmpty().WithMessage(" password is required");

        }
    }
   
}
