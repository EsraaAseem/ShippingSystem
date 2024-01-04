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
    public class ShipmentStatusRepository : Repository<ShipmentStatus>, IShipmentStatusRepository
    {
        private readonly ApplicationDbContext _db;
        public ShipmentStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ShipmentStatus> UpdateShipmentStatusAsync(int id,ShipmentStatusUpdateDto ShipmentStatuspdate)
        {
            var shipmentStatus = _db.shipmentStatuses.FirstOrDefault(c => c.ShipmentStatusId == id);
            if (ShipmentStatuspdate == null)
                throw new NotFoundException("shipment status not found");
                shipmentStatus.ShipmentStatusName = ShipmentStatuspdate.ShipmentStatusName;
                shipmentStatus.ShipmentStatusDescription = ShipmentStatuspdate.ShipmentStatusDescription;
                _db.shipmentStatuses.Update(shipmentStatus);
                await _db.SaveChangesAsync();
                return shipmentStatus;
          
        }
}   }

