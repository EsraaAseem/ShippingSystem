using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.CheckOtp
{
    public record CheckOtpCommand(string otp):ICommand<BaseResponse>;
}
