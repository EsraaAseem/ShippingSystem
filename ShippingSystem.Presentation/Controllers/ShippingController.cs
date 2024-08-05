using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShippingSystem.Application.Cqrs.Clients.Commands.UpdateClient;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefused;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefusedWithoutPay;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRequests;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsShipping;
using ShippingSystem.Application.Cqrs.Clients.Queries.ShipedOrders;
using ShippingSystem.Application.Cqrs.Shipments.Commands.AddShipment;
using ShippingSystem.Application.Cqrs.Shipments.Commands.FundsSettledShipment;
using ShippingSystem.Application.Cqrs.Shipments.Commands.UpdateShipmentStatus;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Application.Cqrs.Shippings.Commands.ShippingIsFinished;
using ShippingSystem.Application.Cqrs.Shippings.Commands.UpdateShippingLocation;
using ShippingSystem.Application.Cqrs.Shippings.Quries.GetRepresentativeShipping;
using ShippingSystem.Application.Cqrs.Shippings.Quries.GetSystemShippings;
using ShippingSystem.Presentation.Abstractions;


namespace WebChat.Presentation.Controllers
{

    [Route("api/[controller]")]
    public class ShippingController : ApiController
    {     
        public ShippingController(ISender sender) : base(sender)
        {
        }
       
        [HttpPost("add/shipping")]
        public async Task<IActionResult> AddShipping([FromBody] AddShippingCommand command, CancellationToken cancellationToken)
        {
          var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("shipments/shipped/{clientId}")]
        public async Task<IActionResult> GetShippedShipments([FromRoute] ShippedOrderQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpPut("update/shipping/location")]
        public async Task<IActionResult> UpdateShippingLocation([FromBody] UpdateShippingLocationCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("update/shipping/finished")]
        public async Task<IActionResult> UpdateShippingFinished([FromBody] UpdateShippingStatusCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        
        [HttpGet("representative/shipping")]
        public async Task<IActionResult> RepresentativeShipping([FromRoute] RepresentativeShippingQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("system/shipping")]
        public async Task<IActionResult> ShipmentsShipping([FromRoute] ShippingsQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
       
    }

}

