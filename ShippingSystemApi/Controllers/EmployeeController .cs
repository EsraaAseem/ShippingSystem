using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.AuthService;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Utility;
using System.Net;

namespace ShippingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authservice;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authservice = authService;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost("EmployeeRegister")]
        public async Task<IActionResult> EmployeeRegisterAsync([FromBody] EmployeeCreateDto model)
        {
            var employee = _mapper.Map<RegisterDto>(model);
            var result = await _authservice.RegisterAsync(employee);
            return Ok(result); 
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync(includeProperity: "employeeRole");
           _response.Result = _mapper.Map<List<EmployeeDto>>(employees);
           return Ok(_response);
        }
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetEmployee([FromRoute] string Id)
        {
          var employee = await _unitOfWork.Employees.GetFirstOrDefualtAsync(u=>u.Id==Id,includeProperity: "employeeRole");
          if (employee == null)
          throw new NotFoundException("this is employee not found");
          _response.Result = _mapper.Map<EmployeeDto>(employee);
          _response.Message = "Get Employee Success";
           return Ok(_response);
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> UpdateEmployee([FromRoute] string Id,EmployeeUpdateDto employeeupdate)
        {
          var employeeupdated = await _unitOfWork.Employees.UpdateEmployeeAsync(Id, employeeupdate);
          _response.Result = employeeupdated;
            _response.Message = "Employee Update Success";
          return Ok(_response);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> DeleteEmployee([FromRoute] string Id)
        {
          var employeeexit = await _unitOfWork.Employees.GetFirstOrDefualtAsync(u => u.Id == Id);
          if (employeeexit == null)
          throw new NotFoundException("this is employee not found");          
          await _unitOfWork.Employees.removeAsync(employeeexit);
          _unitOfWork.SaveAsync();
            _response.Message = "Employee Removed Success";
          return Ok(_response);
         
        }
    }
}
