using AutoMapper;
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
    public class CourierController : ControllerBase
    {
        private readonly IAuthService _authservice;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public CourierController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, IAuthService authService)
        {
            _authservice = authService;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost("CourierRegister")]
        public async Task<IActionResult> CourierRegisterAsync([FromBody] CourierCreateDto model)
        {
            var courier = _mapper.Map<RegisterDto>(model);
            var result = await _authservice.RegisterAsync(courier);
               return Ok(result);
         }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetCouriers()
        {
           var couriers = await _unitOfWork.Couriers.GetAllAsync();
          _response.Result = _mapper.Map<List<CourierDto>>(couriers);
            _response.Message = "Get Couriers Success";
          return Ok(_response);
          
        }
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetCourier([FromRoute] string Id)
        {
          var client = await _unitOfWork.Couriers.GetFirstOrDefualtAsync(u => u.Id == Id);
            if (client == null)
              throw new NotFoundException("this is Courier not found");
              _response.Result = _mapper.Map<CourierDto>(client);
              _response.Message = "Get Courier Success";
               return Ok(_response);          
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> UpdateCourier([FromRoute] string Id, CourierUpdateDto courierupdate)
        {
          var courierupdated = await _unitOfWork.Couriers.UpdateCourierAsync(Id, courierupdate);
          _response.Result = courierupdated;
            _response.Message = "Courier Update Success";
            return Ok(_response);
             
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> DeleteCourier([FromRoute] string Id)
        {
            var courierexit = await _unitOfWork.Couriers.GetFirstOrDefualtAsync(u => u.Id == Id);
            if (courierexit == null)
            throw new NotFoundException("this is Courier not found");
            await _unitOfWork.Couriers.removeAsync(courierexit);
           _unitOfWork.SaveAsync();
           _response.Message = "Client Update Success";
           return Ok(_response);
           
        }
    }
}
