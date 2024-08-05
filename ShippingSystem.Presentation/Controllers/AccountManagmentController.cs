using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.AccountManagment.CheckOtp;
using ShippingSystem.Application.Cqrs.AccountManagment.ConfirmEmail;
using ShippingSystem.Application.Cqrs.AccountManagment.ForgetPassword;
using ShippingSystem.Application.Cqrs.AccountManagment.ResetPassword;
using ShippingSystem.Application.Cqrs.AccountManagment.SendEmailOtp;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using ShippingSystem.Application.Cqrs.Authentication.Login;
using ShippingSystem.Application.Cqrs.Authentication.Representatives.RepresentativeRegister;
using ShippingSystem.Presentation.Abstractions;
using ShippingSystem.Shared;

namespace WebChat.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AccountManagmentController : ApiController
    {     
        public AccountManagmentController(ISender sender) : base(sender)
        {
        }
        [HttpPost("checkOtp")]
        public async Task<IActionResult> RegisterClientAsync([FromBody] CheckOtpCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("confirm/email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailCommand command, CancellationToken cancellationToken)
        {
          
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("forget/password")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("reset/password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("send/email/otp")]
        public async Task<IActionResult> SendEmailOtp(SendOtpCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }


    }
}

