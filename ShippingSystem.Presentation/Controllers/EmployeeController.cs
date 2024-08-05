using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using ShippingSystem.Application.Cqrs.Authentication.Employees.EmployeeRegister;
using ShippingSystem.Application.Cqrs.Authentication.Login;
using ShippingSystem.Application.Cqrs.Beackups.Commands.UpdateBeackupStatus;
using ShippingSystem.Application.Cqrs.Beackups.Queries.GetBeackup;
using ShippingSystem.Application.Cqrs.Cities.Commands.AddCity;
using ShippingSystem.Application.Cqrs.Cities.Commands.UpdateCity;
using ShippingSystem.Application.Cqrs.Cities.Queries.GetCities;
using ShippingSystem.Application.Cqrs.Cities.Queries.GetCity;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFees;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesBeackup;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesInvoices;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesMovingShipments;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.PaidDeliveryFeesShipments;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.UpdateEmployeeProfile;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.GetEmployeeProfile;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.Indebtes;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Quries.Notifactions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.RejectAddClient;
using ShippingSystem.Application.Cqrs.Governorates.Commands.AddGovernorate;
using ShippingSystem.Application.Cqrs.Governorates.Commands.UpdateCovernorate;
using ShippingSystem.Application.Cqrs.Governorates.Queries.GetGovernorate;
using ShippingSystem.Application.Cqrs.Governorates.Queries.GetGovernorates;
using ShippingSystem.Application.Cqrs.Invoices.Commands.CreateInvoice;
using ShippingSystem.Application.Cqrs.Invoices.Quries.GetClientInvoices;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
using ShippingSystem.Application.Cqrs.Vehicles.Quries.GetVehicles;
using ShippingSystem.Presentation.Abstractions;
using ShippingSystem.Shared;

namespace WebChat.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ApiController
    {     
        public EmployeeController(ISender sender) : base(sender)
        {
        }

        [HttpPost("add/employee")]
        public async Task<IActionResult> RegisterEmployeeAsync([FromBody] EmployeeRegCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                var res = await BaseResponse.BadRequestResponsAsync("model not valid");
                return Ok(res);
            }
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("confirm/add/client")]
        public async Task<IActionResult> ConfirmAddClient([FromForm] AddClientResponseCommand command, CancellationToken cancellationToken)
        {
           
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("reject/add/client")]
        public async Task<IActionResult> RejectAddClient([FromForm] RejectAddClientCommand command, CancellationToken cancellationToken)
        {

            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("add/vehicle")]
        public async Task<IActionResult> AddVehicle([FromBody] AddVehicleCommand command, CancellationToken cancellationToken)
        {
          var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("vehicles")]
        public async Task<IActionResult> GetVehicles([FromRoute] VehiclesQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpPost("add/invoice")]
        public async Task<IActionResult> AddInvoice([FromBody] CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("add/governorate")]
        public async Task<IActionResult> AddGovernorate([FromBody] AddGovernorateCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("update/governorate")]
        public async Task<IActionResult> UpdateGovernorate([FromBody] UpdateCovernorateCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("governorates")]
        public async Task<IActionResult> GetGovernorates([FromRoute] GetGovernoratesQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("governorate/{id}")]
        public async Task<IActionResult> GetGovernorate([FromRoute] GetGovernorateQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpPost("add/city")]
        public async Task<IActionResult> AddCity([FromBody] AddCityCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("add/shipping")]
        public async Task<IActionResult> Addshipping([FromBody] AddShippingCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("beackup/status")]
        public async Task<IActionResult> UpdateBeackupStatus([FromBody] UpdateBeackupStatusCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
       
        [HttpPut("city")]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("city/{name}")]
        public async Task<IActionResult> GetCity([FromRoute] CityQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("cities")]
        public async Task<IActionResult> GetCities([FromRoute] CitiesQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpPut("paid/deliveryFees")]
        public async Task<IActionResult> PaidDeliveryFees([FromBody] PaidDeliveryFeesCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);

        }
        [HttpPut("paid/deliveryFees/beackup")]
        public async Task<IActionResult> PaidDeliveryFeesBeackup([FromBody] PaidDeliveryFeesBeackupCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("paid/deliveryFees/invoice")]
        public async Task<IActionResult> PaidDeliveryFeesInvoices([FromBody] PaidDeliveryFeesInvoicesCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("paid/deliveryFees/movingShipments")]
        public async Task<IActionResult> PaidDeliveryFeesMovingShipments([FromBody] PaidDeliveryFeesMovingShipmentsCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("paid/deliveryFees/shipments")]
        public async Task<IActionResult> PaidDeliveryFeesShipmentsCommand([FromBody] PaidDeliveryFeesShipmentsCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("update/profile")]
        public async Task<IActionResult> UpdateEmployeeProfile([FromBody] UpdateEmployeeProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("profile/{employeeId}")]
        public async Task<IActionResult> EmployeeProfile([FromRoute] EmployeeProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("notifactions")]
        public async Task<IActionResult> GetNotifactions([FromRoute] NotifactionQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("company/indebtes")]
        public async Task<IActionResult> CompanyIndebtes([FromRoute] IndebtesQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices([FromRoute] ClientInvoicesQuery query, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}

