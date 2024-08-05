using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Beackups.Commands.AddBeackup;
using ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackup;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientRquests;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientShipping;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupRequestsQuery;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupsShipping;
using ShippingSystem.Application.Cqrs.Beackups.Queries.GetBeackup;
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

        [HttpPost("update/Beackup")]
        public async Task<IActionResult> UpdateBeackup([FromBody] UpdateBeackupCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("clientRequest/{clientId}")]
        public async Task<IActionResult> BeackupClientRequests([FromRoute] BeackupClientRequestsQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("clientShipping/{clientId}")]
        public async Task<IActionResult> BeackupClientShipping([FromRoute] BeackupClientShippingQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("Requests")]
        public async Task<IActionResult> BeackupRequests([FromRoute] BeackupRequestsQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("shipping")]
        public async Task<IActionResult> BeackupShipping([FromRoute] BeackupShippingQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("getBeackups/{beackupId}")]
        public async Task<IActionResult> GetBeackup([FromRoute] GetBeackupQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

    }
}

