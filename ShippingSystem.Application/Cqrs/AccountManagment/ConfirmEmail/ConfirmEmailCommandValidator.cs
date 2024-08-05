﻿using FluentValidation;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail
{
    internal class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage(" Email Reqguired");
        }
    }
}
