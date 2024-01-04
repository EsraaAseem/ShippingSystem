using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.BaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Utility;


namespace ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository
{
    public class BackupStatusRepository : Repository<BackupStatus>, IBackupStatusRepository
    {
        private readonly ApplicationDbContext _db;
        public BackupStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<BackupStatus> UpdateBackupStatusAsync(int id,BackupStatusUpdateDto backupstatusupdate)
        {
            var backUp = await _db.BackupStatuses.FirstOrDefaultAsync(c => c.Id == id);
            if (backUp == null)
                throw new NotFoundException("this beackup not found");
            backUp.StatusName = backupstatusupdate.StatusName;
                _db.BackupStatuses.Update(backUp);
                await _db.SaveChangesAsync();
            return backUp;            
        }
    }
}
