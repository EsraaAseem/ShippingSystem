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
    public class BackupStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly BaseResponse _response;
        private readonly IMapper _mapper;
        public BackupStatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._response = new();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBackupStatus([FromBody] BackupStatusCreateDto model)
        {
           var BackupCreated = _mapper.Map<BackupStatus>(model);
           var result = await _unitOfWork.BackupStatus.AddAsync(BackupCreated);
           _unitOfWork.SaveAsync();
           _response.Result = result;
           return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBackupsStatus()
        {
           
          var backups = await _unitOfWork.BackupStatus.GetAllAsync();
          _response.Result = _mapper.Map<List<BackupStatusDto>>(backups);
          return Ok(_response);
            
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBackup([FromRoute] int Id)
        {
           
         var backup = await _unitOfWork.BackupStatus.GetFirstOrDefualtAsync(u => u.Id == Id);
            if (backup == null)
                throw new NotFoundException("this is Backup Status not found");
            
              _response.Result = _mapper.Map<BackupStatusDto>(backup);
              return Ok(_response);
          
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBackup([FromRoute] int Id, BackupStatusUpdateDto Backupupdate)
        {
           
          var Backupupdated = await _unitOfWork.BackupStatus.UpdateBackupStatusAsync(Id, Backupupdate);
         _response.Result = Backupupdated;
              
          return Ok(_response);

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBackupStatus([FromRoute] int Id)
        {
           
          var BackupStatusExit = await _unitOfWork.BackupStatus.GetFirstOrDefualtAsync(u => u.Id == Id);
            if (BackupStatusExit == null)
                throw new NotFoundException("this Backup Status not found in the databasse");
                await _unitOfWork.BackupStatus.removeAsync(BackupStatusExit);
                _unitOfWork.SaveAsync();
                return Ok(_response);
         
        }
    }
}
