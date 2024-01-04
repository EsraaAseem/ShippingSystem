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
    public class BackupRepository : Repository<BackUp>, IBackupRepository
    {
        private readonly ApplicationDbContext _db;
        public BackupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<BackUp> UpdateBackupAsync(Guid id, BackupUpdateDto backupeupdate)
        {

            var backUp = await _db.BackUps.FirstOrDefaultAsync(c => c.BackupId == id);
            if (backUp == null)
                throw new NotFoundException("beackup not found in system");
                backUp.BackupStatus = backupeupdate.BackupStatus;
                backUp.ClientId = backupeupdate.ClientId;
                backUp.FromShippingTime = backupeupdate.FromShippingTime;
                backUp.ToShippingTime = backupeupdate.ToShippingTime;
                backUp.RecivedTime = backupeupdate.RecivedTime;
                backUp.ShippingNumber = backupeupdate.ShippingNumber;
                backUp.VehicleId = backupeupdate.VehicleId;
                _db.BackUps.Update(backUp);
                await _db.SaveChangesAsync();               
                return backUp;
        }
    }
}
