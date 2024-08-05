using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Beackups.Queries.GetBeackup;
using ShippingSystem.Application.Cqrs.Clients.Commands.UpdateClient;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientProfile;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefused;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsRefusedWithoutPay;
using ShippingSystem.Application.Cqrs.Clients.Queries.ClientShipmentsShipping;
using ShippingSystem.Application.Cqrs.Clients.Queries.Indebtedness;
using ShippingSystem.Application.Cqrs.Clients.Queries.Indebtes;
using ShippingSystem.Application.Cqrs.Clients.Queries.Notifications;
using ShippingSystem.Application.Cqrs.Clients.Queries.ShipedOrders;
using ShippingSystem.Presentation.Abstractions;

namespace WebChat.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : ApiController
    {     
        public ClientController(ISender sender) : base(sender)
        {
        }

        [HttpPut("update/{clientId}")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientCommand command, CancellationToken cancellationToken)
        {
          var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("profile/{clientId}")]
        public async Task<IActionResult> GetCLientProfile([FromRoute] ClientProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("shipments/refused/{clientId}")]
        public async Task<IActionResult> GetClientShipmentsRefused([FromRoute] ShipmentsClientRejectedQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("shipments/paidRefused/{clientId}")]
        public async Task<IActionResult> GetClientShipmentsPaidRefused([FromRoute] ShipmentsPaidRejectedQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("shipments/clientShipping/{clientId}")]
        public async Task<IActionResult> ShipmentsClientShipping([FromRoute]  ShipmentsClientShippingQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("indebtes/client/{clientId}")]
        public async Task<IActionResult> IndebtesClient([FromRoute] IndebtesClientQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("indebtedness/client/{clientId}")]
        public async Task<IActionResult> IndebtednessClient([FromRoute] IndebtednessClientQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("notifactions/{clientId}")]
        public async Task<IActionResult> ClientNotifactions([FromRoute] ClientNotifactionsQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("shippedOrder")]
        public async Task<IActionResult> ShippedOrder([FromRoute] ShippedOrderQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
       

    }
}

