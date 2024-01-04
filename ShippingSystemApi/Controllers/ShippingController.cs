using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Utility;
using System.Net;

namespace ShippingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public ShippingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateDeliveryShipment([FromBody] ShippingCreateDto model)
        {
           
                var deliveryShipment = _mapper.Map<Shipping>(model);
                var result = await _unitOfWork.DeliveryShipments.AddAsync(deliveryShipment);
                _unitOfWork.SaveAsync();
                _response.Result = result;
      
            return Ok(_response);
        }

    /*    [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetEmployeeRoles()
        {
            
                var employeeRoles = await _unitOfWork.EmployeeRoles.GetAllAsync();
                _response.Result = _mapper.Map<List<EmployeeRole>>(employeeRoles);
                return Ok(_response);
            
        }
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetEmployeeRole([FromRoute] int Id)
        {
          var employeeRole = await _unitOfWork.EmployeeRoles.GetFirstOrDefualtAsync(u => u.RoleId == Id);
          if (employeeRole == null)
          throw new NotFoundException("this is Employee Role not found");
          _response.Result = _mapper.Map<EmployeeRoleDto>(employeeRole);
          _response.Message = "Get Employee Success";
           return Ok(_response);
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> UpdateEmployeeRole([FromRoute] int Id, EmployeeRoleEditDto employeeRoleupdate)
        {
           var employeeRoleupdated = await _unitOfWork.EmployeeRoles.UpdateEmployeeRoleAsync(Id, employeeRoleupdate);
           _response.Result = employeeRoleupdated;
            _response.Message = "Employee Update Success";
            return Ok(_response);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> DeleteEmployee([FromRoute] int Id)
        {
          var employeeRoleexit = await _unitOfWork.EmployeeRoles.GetFirstOrDefualtAsync(u => u.RoleId == Id);
          if (employeeRoleexit == null)
          throw new NotFoundException("this is Employee Role not found");
          await _unitOfWork.EmployeeRoles.removeAsync(employeeRoleexit);
         _unitOfWork.SaveAsync();
          _response.Message = "Employee Remove success";
          return Ok(_response);
        }*/
    }
}
