using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail;
using ShippingSystem.Application.Cqrs.AccountManagment.SendEmailOtp;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.AccountManagment.CheckOtp
{
    internal class CheckOtpCommandHandler : ICommandHandler<CheckOtpCommand, BaseResponse>
    {
        private readonly IMailServices _mailService;
        private readonly IStringLocalizer<CheckOtpCommandHandler> _localization;

        public CheckOtpCommandHandler(IMailServices mailService, IStringLocalizer<CheckOtpCommandHandler> localization)
        {
            _mailService = mailService;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(CheckOtpCommand request, CancellationToken cancellationToken)
        {
            bool response = _mailService.CheckOtp(request.otp);
            return await BaseResponse.SuccessResponseWithDataAndMsgAsync(response, _localization["OtpisCorrect"].Value);

        }
    }
}
