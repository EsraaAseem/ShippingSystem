using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup;
using ShippingSystem.Presentation.Abstractions;

namespace WebChat.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class BeackupController : ApiController
    {     
        public BeackupController(ISender sender) : base(sender)
        {
        }

        [HttpPost("add/Beackup")]
        public async Task<IActionResult> AddBeackup([FromBody] AddBeackupCommand command, CancellationToken cancellationToken)
        {
          var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }

    }
}

