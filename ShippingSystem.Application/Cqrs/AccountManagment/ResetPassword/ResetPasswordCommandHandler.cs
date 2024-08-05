

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail;
using ShippingSystem.Application.Cqrs.AccountManagment.ForgetPassword;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;

namespace ShippingSystem.Application.Cqrs.AccountManagment.ResetPassword
{
    internal class ResetPasswordCommandHandler:ICommandHandler<ResetPasswordCommand,BaseResponse>
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IStringLocalizer<ResetPasswordCommandHandler> _localization;

        public ResetPasswordCommandHandler(UserManager<AppUser> userManager, IStringLocalizer<ResetPasswordCommandHandler> localization)
        {
            _userManager = userManager;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if (user == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundUser"].Value);
            if (!await _userManager.CheckPasswordAsync(user, request.oldPassword))
            {
                return await BaseResponse.BadRequestResponsAsync(_localization["ErrorOnChangePassword"].Value);
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, request.newPassword);
            if (!result.Succeeded)
                return await BaseResponse.BadRequestResponsAsync(_localization["ForgetPasswordFaild"].Value);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["ResetPasswordSuccess"].Value);
        }
    }
}
