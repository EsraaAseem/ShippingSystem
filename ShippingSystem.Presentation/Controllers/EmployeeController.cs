using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using ShippingSystem.Application.Cqrs.Authentication.Employees.EmployeeRegister;
using ShippingSystem.Application.Cqrs.Authentication.Login;
using ShippingSystem.Application.Cqrs.Cities.Commands.AddCity;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.RejectAddClient;
using ShippingSystem.Application.Cqrs.Governorates.Commands.AddGovernorate;
using ShippingSystem.Application.Cqrs.Shippings.Commands.AddShipping;
using ShippingSystem.Application.Cqrs.Vehicles.Commands.AddVehicle;
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
        [HttpPost("add/governorate")]
        public async Task<IActionResult> AddGovernorate([FromBody] AddGovernorateCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
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


    }
}

