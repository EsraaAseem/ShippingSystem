using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Beackups.Queries.BeackupClientShipping;
using ShippingSystem.Application.Cqrs.Representatives.Commands.UpdateRepresentative;
using ShippingSystem.Application.Cqrs.Representatives.Queries.DeliveryFees;
using ShippingSystem.Application.Cqrs.Representatives.Queries.Indebtes;
using ShippingSystem.Application.Cqrs.Representatives.Queries.Notifactions;
using ShippingSystem.Application.Cqrs.Representatives.Queries.RepresentativeProfile;
using ShippingSystem.Presentation.Abstractions;

namespace WebChat.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class RepresentativeController : ApiController
    {     
        public RepresentativeController(ISender sender) : base(sender)
        {
        }

        [HttpPost("update/profile")]
        public async Task<IActionResult> UpdateRepresentativeProfile([FromBody] UpdateRepresentativeCommand command, CancellationToken cancellationToken)
        {
          var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("deliveryFees/{representativeId}")]
        public async Task<IActionResult> BeackupClientShipping([FromRoute] DeliveryFeesQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("indebtes/{representativeId}")]
        public async Task<IActionResult> IndebtesRepresentative([FromRoute] IndebtesRepresentativeQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("notifactions/{representativeId}")]
        public async Task<IActionResult> NotifactionsRepresentative([FromRoute] NotifactionsRepresentativeQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("profile/{representativeId}")]
        public async Task<IActionResult> RepresentativeProfile([FromRoute] RepresentativeProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}

