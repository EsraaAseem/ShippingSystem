using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.BaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;


namespace ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository
{
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        private readonly ApplicationDbContext _db;
        public AreaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Area> UpdateAreaAsync(int id, AreaUpdateDto areaUpdate)
        {
            var area = await _db.Areas.FirstOrDefaultAsync(c => c.AreaId == id);
            if (area == null)
                throw new NotFoundException("Area not found");
                area.ShippingPrice = areaUpdate.ShippingPrice;
                area.ReturnShippingPrice = areaUpdate.ReturnShippingPrice;
                area.ExcessShippingPrice = areaUpdate.ExcessShippingPrice;
                area.AreaName = areaUpdate.AreaName;
               var res = _db.Areas.Update(area);
            if (res.State != EntityState.Modified)
            {
                throw new BadRequestException("Error Occure un Update Area");
            }
                await _db.SaveChangesAsync();

            return  area;
        }

    }
}
