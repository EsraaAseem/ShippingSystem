using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.AuthService;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Service.ImagesService;
using ShippingSystem.Utility;


namespace ShippingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IAuthService _authservice;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public ClientController(IUnitOfWork unitOfWork,IMapper mapper, IAuthService authService,IPhotoService photoService)
        {
            _authservice = authService;
            _photoService = photoService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost("ClientRegister")]
        public async Task<IActionResult> ClientRegisterAsync([FromForm] ClientCreateDto model)
        {
           
            var client = _mapper.Map<RegisterDto>(model);
            var result = await _authservice.RegisterAsync(client);
            return Ok(result);
        }
       
        [HttpGet("GetClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClients()
        {

          var clients = await _unitOfWork.Clients.GetAllAsync();
           _response.Result = _mapper.Map<List<ClientDto>>(clients);
           return Ok(_response);
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClient([FromRoute] string Id)
        {
           var client = await _unitOfWork.Clients.GetFirstOrDefualtAsync(u=>u.Id==Id);
            if (client == null)
            throw new NotFoundException("this Client not found in the databasse");
           _response.Result = _mapper.Map<ClientDto>(client);
            _response.Message = "Get Client success";
           return Ok(_response);
        
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateClient([FromRoute] string Id,ClientUpdateDto clientupdate)
        {
            var client = await _unitOfWork.Clients.GetFirstOrDefualtAsync(c => c.Id == Id);
            if (client == null)
                throw new NotFoundException("Client not found");
            if(clientupdate.Image != null)
            {
                var photo=await _photoService.UpdateImageAsync(client.Logo, clientupdate.Image);
                clientupdate.Logo = photo;
            }
           
            var clientupdated = await _unitOfWork.Clients.UpdateClientAsync(client, clientupdate);
              _response.Result = clientupdated;
            _response.Message = "Client update success";
           return Ok(_response);
             
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] string Id)
        {
          var clientexit = await _unitOfWork.Clients.GetFirstOrDefualtAsync(u => u.Id == Id);
          if (clientexit == null)
          throw new NotFoundException("this Client not found in the databasse");
          
          if(clientexit.Logo!=null)
           {
                await _photoService.RemoveImageAsync(clientexit.Logo);
           }
          await _unitOfWork.Clients.removeAsync(clientexit);
          _unitOfWork.SaveAsync();
            _response.Message="Client delete success";
           return Ok(_response);
        }

       /* [HttpPost("Image")]
        public async Task<IActionResult> ImageClient( IFormFile image)
        {
            return Ok(_authservice.Image(image));
        }*/
      
    }
}
