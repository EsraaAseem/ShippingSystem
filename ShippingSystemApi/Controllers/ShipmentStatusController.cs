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
    public class ShipmentStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public ShipmentStatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateShipmentStatus([FromBody] ShipmentStatusCreateDto model)
        {
          
            var shipExited = await _unitOfWork.ShipmentStatus.GetFirstOrDefualtAsync(x => x.ShipmentStatusName == model.ShipmentStatusName);
              if(shipExited!=null)
                throw new BadHttpRequestException("this already exit");
             var shipst = _mapper.Map<ShipmentStatus>(model);
                var result = await _unitOfWork.ShipmentStatus.AddAsync(shipst);
                _unitOfWork.SaveAsync();
                _response.Result = result;
            _response.Message = "ship status created success";
              return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetShipmentStatus()
        { 
          var shipmentStatus = await _unitOfWork.ShipmentStatus.GetAllAsync();
           _response.Result = _mapper.Map<List<ShipmentStatusDto>>(shipmentStatus);
          return Ok(_response);
        }
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetShipmentStatus([FromRoute] int Id)
        {
            
                var shipmentStatus = await _unitOfWork.ShipmentStatus.GetFirstOrDefualtAsync(u => u.ShipmentStatusId == Id);
            if (shipmentStatus == null)
                throw new NotFoundException("shipment status not found");

                    _response.Result = _mapper.Map<ShipmentStatusDto>(shipmentStatus);               
                   // _response.ErrorMessages = new List<string>() { "this is Shipment Status not found" };
                    return Ok(_response);
                
       
        }
        [HttpPut]
        [Route("{ShipmentStatusId}")]
        public async Task<ActionResult<BaseResponse>> UpdateShipmentStatus([FromRoute] int ShipmentStatusId, ShipmentStatusUpdateDto shipmentStatusupdate)
        {
           var res= await _unitOfWork.ShipmentStatus.UpdateShipmentStatusAsync(ShipmentStatusId, shipmentStatusupdate);
          _response.Result = res;
            _response.Message = "Shipment status Update Success";
         return Ok(_response);
        }
        [HttpDelete]
        [Route("{ShipmentStatusId}")]
        public async Task<ActionResult<BaseResponse>> DeleteShipmentStatus([FromRoute] int ShipmentStatusId)
        {
          var ShipmentStatusexit = await _unitOfWork.ShipmentStatus.GetFirstOrDefualtAsync(u => u.ShipmentStatusId == ShipmentStatusId);
          if (ShipmentStatusexit == null)
          throw new NotFoundException("shipment status not found");
          await _unitOfWork.ShipmentStatus.removeAsync(ShipmentStatusexit);
          _unitOfWork.SaveAsync();
         _response.Message = "Shipment status removed success";
         return Ok(_response);
          
        }
    }
}
