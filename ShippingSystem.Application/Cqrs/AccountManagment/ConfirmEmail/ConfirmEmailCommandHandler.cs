using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail
{
    internal class ConfirmEmailCommandHandler : ICommandHandler<ConfirmEmailCommand, BaseResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStringLocalizer<ConfirmEmailCommandHandler> _localization;

        public ConfirmEmailCommandHandler(UserManager<AppUser> userManager, IStringLocalizer<ConfirmEmailCommandHandler> localization)
        {
            _userManager = userManager;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if(user == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundUser"].Value);
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["ConfirmEmailSuccess"].Value);
        }
    }
}
