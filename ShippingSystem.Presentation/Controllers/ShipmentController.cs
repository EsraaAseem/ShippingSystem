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
using ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsRejected;
using ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsShipped;
using ShippingSystem.Application.Cqrs.Shipments.Queries.ShipmentsShipping;
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
        // clientUserName - CityName - paymentStatus - shipmentType - movedDate -
        // reciver(name - city - streetAddress - email - phone )-
        // List<AddProduct> products (productName - amount - productPrice - productWeight)

        [HttpPost("add/shipment/byExcel")]
        public async Task<IActionResult> AddShipmentByExcel([FromBody] AddShipmentByExcelCommand command, CancellationToken cancellationToken)
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
        [HttpPut("fundsSettled")]
        public async Task<IActionResult> FundsSettledShipment([FromBody] FundsSettledShipmentCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("update/status")]
        public async Task<IActionResult> UpdateShipmentStatus([FromBody] UpdateShipmentStatusCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("shipments/refused")]
        public async Task<IActionResult> GetShipmentsRefused([FromRoute] ShipmentsRejectedQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("shipments/paidRefused")]
        public async Task<IActionResult> GetShipmentsPaidRefused([FromRoute] ShipmentsPaidRejectedQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("shipments/clientShipping")]
        public async Task<IActionResult> ShipmentsShipping([FromRoute] ShipmentsShippingQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("shipments/clientShipped")]
        public async Task<IActionResult> ShipmentsShipped([FromRoute] ShipmentsShippedQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        /*  [HttpGet("shipments/shipping/{clientId}")]
          public async Task<IActionResult> GetShippingShipments([FromRoute] ShipmentsClientShippingQuery query, CancellationToken cancellationToken)
          {
              var result = await Sender.Send(query, cancellationToken);
              return Ok(result);
          }
          [HttpGet("shipments/requests/{clientId}")]
          public async Task<IActionResult> GetShipmentsClientRequests([FromRoute] ShipmentsClientRequestsQuery query, CancellationToken cancellationToken)
          {
              var result = await Sender.Send(query, cancellationToken);
              return Ok(result);
          }*/

    }
}

