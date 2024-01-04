using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.BaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository
{
    public class ShippingRepository : Repository<Shipping>, IRepositories.IEntitiesRepository.IShippingRepository
    {
        private readonly ApplicationDbContext _db;
        public ShippingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Shipping> UpdateDeliveryShipmentsAsync(int Id, ShippingUpdateDto DeliveryShipmentsUpdate)
        {
            var deliveryShip = await _db.Shippings.FirstOrDefaultAsync(c => c.ShippingId == Id);
            if (deliveryShip == null)
                throw new NotFoundException("the Shipping not found");
                deliveryShip.CourierId = DeliveryShipmentsUpdate.CourierId;
                deliveryShip.VehicleId = DeliveryShipmentsUpdate.VehicleId;
                deliveryShip.FinishingDate = DeliveryShipmentsUpdate.FinishingDate;
                _db.Shippings.Update(deliveryShip);
                await _db.SaveChangesAsync();
                return deliveryShip;
          
        }
    }
}
