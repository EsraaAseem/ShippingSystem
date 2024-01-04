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
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateVehicle([FromBody] VehicleEdit model)
        {
            var AreaExited = await _unitOfWork.Vehicles.GetFirstOrDefualtAsync(x => x.Name == model.Name);
            if (AreaExited != null)
                throw new BadRequestException("this already exit");
                var vehicle = _mapper.Map<Vehicle>(model);
                var result = await _unitOfWork.Vehicles.AddAsync(vehicle);
                _unitOfWork.SaveAsync();
                _response.Result = result;
               _response.Message = "Create Vehicle Success";
               return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetVehicles()
        {
           
                var vehicles= await _unitOfWork.Vehicles.GetAllAsync();
                _response.Result = _mapper.Map<List<VehicleDto>>(vehicles);
                return Ok(_response);
          
        }
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetVehicle([FromRoute] int Id)
        {

            var vehicle = await _unitOfWork.Vehicles.GetFirstOrDefualtAsync(u => u.Id == Id);
              if (vehicle == null)
                throw new NotFoundException("this is vehicle not found");
              _response.Result = _mapper.Map<VehicleDto>(vehicle);
              _response.Message = "get vehicle success";
                return Ok(_response);
        }
            [HttpPut]
            [Route("{Id}")]
            public async Task<ActionResult<BaseResponse>> UpdateVehicle([FromRoute] int Id, VehicleEdit vehicleUpdate)
            {

                var vehicleUpdated = await _unitOfWork.Vehicles.UpdateVehicleAsync(Id, vehicleUpdate);
               _response.Result = vehicleUpdated;
               _response.Message = "Vehicle Update Success";
                return Ok(_response);

            }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> DeleteVehicle([FromRoute] int Id)
        {

            var vehicleExited = await _unitOfWork.Vehicles.GetFirstOrDefualtAsync(u => u.Id == Id);
            if (vehicleExited == null)
                throw new NotFoundException("this is vehicle not found");
            await _unitOfWork.Vehicles.removeAsync(vehicleExited);
            _unitOfWork.SaveAsync();
            _response.Message = "Vehicle Removed Success";
            return Ok(_response);

        }
        
    }
}
