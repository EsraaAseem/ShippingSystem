using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.AccountManagment.ForgetPassword
{
    internal class ForgetPasswordCommandHandler:ICommandHandler<ForgetPasswordCommand,BaseResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStringLocalizer<ForgetPasswordCommandHandler> _localization;

        public ForgetPasswordCommandHandler(UserManager<AppUser> userManager, IStringLocalizer<ForgetPasswordCommandHandler> localization)
        {
            _userManager = userManager;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if (user == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundUser"].Value);
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, request.newPassword);
            if (!result.Succeeded)
                return await BaseResponse.BadRequestResponsAsync(_localization["ForgetPasswordFaild"].Value); 
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["ResetPasswordSuccess"].Value);
        }
    }
}
