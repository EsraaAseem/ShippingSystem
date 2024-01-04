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
    public class ShipmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public ShipmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<IActionResult> CreateShipment([FromBody] ShipmentCreateDto model)
        {
           
         
               var ship = _mapper.Map<Shipment>(model);
            var area =await _unitOfWork.Area.GetFirstOrDefualtAsync(u => u.AreaId == model.AreaId);
            var shipstatus=await _unitOfWork.ShipmentStatus.GetFirstOrDefualtAsync(s=>s.ShipmentStatusId== model.ShipmentStatusId);
               ship.CalculatePrices(area,shipstatus);
              //shipvalues(ship);
                var result = await _unitOfWork.Shipment.AddAsync(ship);
            if (result == null)
                throw new BadRequestException("error in create shipment");
                _unitOfWork.SaveAsync();
                _response.Result = result;
                return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetShipments()
        {
                var shipments = await _unitOfWork.Shipment.GetAllAsync();
                _response.Result = _mapper.Map<List<ShipmentDto>>(shipments);
                _response.Message = "Get Shipments";
                return Ok(_response);
          
        }
        [HttpGet]
        [Route("{ShipmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetShipment([FromRoute] int ShipmentId)
        {
           var shipment = await _unitOfWork.Shipment.GetFirstOrDefualtAsync(u => u.ShipmentId == ShipmentId);
           if (shipment == null)
          throw new NotFoundException("this is Employee Role not found");
           _response.Result = _mapper.Map<ShipmentDto>(shipment);
           return Ok(_response);
        
        }
        [HttpPut]
        [Route("{ShipmentId}")]
        public async Task<IActionResult> UpdateShipment([FromRoute] int ShipmentId, ShipmentUpdateDto shipmentUpdate)
        {
            //To Do
            var ship = _mapper.Map<Shipment>(shipmentUpdate);
            await shipvalues(ship);
           var shipmentUpdated = await _unitOfWork.Shipment.UpdateShipmentAsync(ShipmentId, ship);
          _response.Result = shipmentUpdate;
           return Ok(_response);
         
        }
        [HttpDelete]
        [Route("{ShipmentId}")]
        public async Task<ActionResult<BaseResponse>> DeleteShipment([FromRoute] int ShipmentId)
        {
                var shipmentExit = await _unitOfWork.Shipment.GetFirstOrDefualtAsync(u => u.ShipmentId == ShipmentId);
                if (shipmentExit == null)
               throw new NotFoundException("this Shipment not found in the databasse");
                await _unitOfWork.Shipment.removeAsync(shipmentExit);
                _unitOfWork.SaveAsync();
                 _response.Message = "Shipment Delete Success";
                return Ok(_response);
        }

        private async Task  shipvalues(Shipment ship)
        {
           // Area area = await _unitOfWork.Area.GetFirstOrDefualtAsync(x => x.AreaId == ship.AreaId);

           /* if (ship.PaymentStatus == PaymentStatus.PrePaid)
            {
                if (ship.ShipmentStatusId == 1)
                {
                    ship.TotalPrice = area.ReturnShippingPrice;
                    ship.ShippingPrice = area.ReturnShippingPrice;

                }
                else
                {
                    ship.TotalPrice = area.ShippingPrice;
                    ship.ShippingPrice = area.ShippingPrice;
                }
            }
            else
            {

                foreach (var pro in ship.Products)
                {
                    pro.ProductTotalPrice = pro.Amount * pro.ProductPrice;
                    pro.ProductTotalWeight = pro.Amount * pro.ProductWeight;
                    ship.TotalProductsPrice += pro.ProductTotalPrice;
                    ship.TotalWight += pro.ProductTotalWeight;
                }
                /*if (ship.ShippingStatus.ShipmentStatusName == "NotCompleted")
                    ship.ShippingPrice = area.ReturnShippingPrice;
                else*/
               /* ship.ShippingPrice = area.ShippingPrice;
                if (ship.TotalWight > 1)
                {
                    ship.ShippingPrice += (ship.TotalWight - 1) * area.ExcessShippingPrice;

                }
                ship.TotalPrice = ship.ShippingPrice + ship.TotalProductsPrice;*/
            
        }
    }
}
