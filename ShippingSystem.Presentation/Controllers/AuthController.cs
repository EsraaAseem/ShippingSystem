using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using ShippingSystem.Application.Cqrs.Authentication.Login;
using ShippingSystem.Application.Cqrs.Authentication.Representatives.RepresentativeRegister;
using ShippingSystem.Presentation.Abstractions;
using ShippingSystem.Shared;

namespace WebChat.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ApiController
    {     
        public AuthController(ISender sender) : base(sender)
        {
        }
        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClientAsync([FromForm] ClientRegCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("register/representative")]
        public async Task<IActionResult> RegisterRepresentativeAsync([FromBody] RepresentativeRegCommand command, CancellationToken cancellationToken)
        {
          
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        
    }
}

