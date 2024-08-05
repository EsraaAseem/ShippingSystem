using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using ShippingSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Cqrs.AccountManagment.SendEmailOtp
{
    internal class SendOtpCommandHandler : ICommandHandler<SendOtpCommand, BaseResponse>
    {
        private readonly IMailServices _mailService;
       private readonly IStringLocalizer<SendOtpCommandHandler> _localization;

        public SendOtpCommandHandler(IMailServices mailService, IStringLocalizer<SendOtpCommandHandler> localization)
        {
            _mailService = mailService;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(SendOtpCommand request, CancellationToken cancellationToken)
        {
            var otp = _mailService.CallOtp();
            if (_mailService != null)
            {

                await _mailService.SendEmailAsync(
                                mailTo: request.userEmail,
                subject: "Confirm Otp",
                                body: "Your Otp Is"+otp);

            }
            return await BaseResponse.SuccessResponseWithMessageAsync( _localization["SendEmailSuccess"].Value);
        }
    }
}
