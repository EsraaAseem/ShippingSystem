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
    public class BackupController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public BackupController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBackup([FromBody] BackupCreateDto model)
        {
               
                var BackupCreated = _mapper.Map<BackUp>(model);
                var result = await _unitOfWork.BackUp.AddAsync(BackupCreated);
            _response.Result = result;
            _response.Message = "Create Backup Success";
                _unitOfWork.SaveAsync();        
                return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> GetBackups()
        {
           
                var backups = await _unitOfWork.BackUp.GetAllAsync(includeProperity: "Client,Courier,Vehicle");
                _response.Result = _mapper.Map<List<BackupDto>>(backups);
                return Ok(_response);
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBackup([FromRoute] Guid Id)
        {
                           
            var backup = await _unitOfWork.BackUp.GetFirstOrDefualtAsync(u => u.BackupId == Id, includeProperity: "Client,Courier,Vehicle");
            if (backup == null)
                throw new NotFoundException("this is Backup Status not found");

              _response.Result = _mapper.Map<BackupDto>(backup);
               return Ok(_response);
             
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBackup([FromRoute] Guid Id, BackupUpdateDto Backupupdate)
        {
          
                var Backupupdated = await _unitOfWork.BackUp.UpdateBackupAsync(Id, Backupupdate);
                _response.Result = Backupupdated;
                return Ok(_response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBackup([FromRoute] Guid Id)
        {
            
                var BackupExit = await _unitOfWork.BackUp.GetFirstOrDefualtAsync(u => u.BackupId == Id);
               if (BackupExit == null)
                throw new NotFoundException("this is Backup Status not found");

               await _unitOfWork.BackUp.removeAsync(BackupExit);
                _unitOfWork.SaveAsync();
                return Ok(_response);
         
        }
    }
}
