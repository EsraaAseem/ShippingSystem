using FluentValidation;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.ResetPassword
{
    internal class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage(" Email Reqguired");
            RuleFor(x => x.oldPassword).NotEmpty().WithMessage("old password is required");
            RuleFor(x => x.newPassword).NotEmpty().WithMessage(" new password is required");

        }
    }
   
}
