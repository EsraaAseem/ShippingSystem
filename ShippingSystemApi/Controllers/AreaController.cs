using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Utility;

namespace ShippingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public AreaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArea([FromBody] AreaCreateDto model)
        {
            var AreaExited = await _unitOfWork.Area.GetFirstOrDefualtAsync(x => x.AreaName == model.AreaName);
            if (AreaExited != null)
                throw new BadRequestException("this area is already Exit");
                var area = _mapper.Map<Area>(model);
                var result = await _unitOfWork.Area.AddAsync(area);
                _unitOfWork.SaveAsync();
                _response.Result = result;
          
            return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetAreas()
        {
          
          var areas = await _unitOfWork.Area.GetAllAsync();
           _response.Result = _mapper.Map<List<AreaDto>>(areas);
           return Ok(_response);
                   }
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetArea([FromRoute] int Id)
        {
           
             var area = await _unitOfWork.Area.GetFirstOrDefualtAsync(u => u.AreaId == Id);
             if (area == null)
                throw new NotFoundException("this Area not Exsit");

              _response.Result = _mapper.Map<AreaDto>(area);
              return Ok(_response);
        }
        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> UpdateArea([FromRoute] int Id, AreaUpdateDto areaUpdate)
        {
           
           var employeeRoleupdated = await _unitOfWork.Area.UpdateAreaAsync(Id, areaUpdate);
          _response.Result = employeeRoleupdated;
            return Ok(_response);
          
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<BaseResponse>> DeleteArea([FromRoute] int Id)
        {
           var areaExsit = await _unitOfWork.Area.GetFirstOrDefualtAsync(u => u.AreaId == Id);
           if (areaExsit == null)
            throw new NotFoundException("this Area not Exsit");
           var result= await _unitOfWork.Area.removeAsync(areaExsit);
           _unitOfWork.SaveAsync();
          _response.Result = result;
          return Ok(_response);
        
        }
    }
}
