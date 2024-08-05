using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail
{
    public record ConfirmEmailCommand(string email):ICommand<BaseResponse>;
}
