using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment;
using ShippingSystem.Presentation.Abstractions;
using ShippingSystem.Shared;

namespace WebChat.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class ShipmentController : ApiController
    {     
        public ShipmentController(ISender sender) : base(sender)
        {
        }

       
        [HttpPost("add/shipment")]
        public async Task<IActionResult> AddShipment([FromBody] AddShipmentCommand command, CancellationToken cancellationToken)
        {
          var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }

    }
}

