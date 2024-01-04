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
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        private readonly ApplicationDbContext _db;
        public ShipmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Shipment> UpdateShipmentAsync(int Id, Shipment Shipmentpdate)
        {
            var shipment = await _db.Shipments.FirstOrDefaultAsync(c => c.ShipmentId == Id);
            if (shipment == null)
                throw new NotFoundException("this shipment not found");
              //  shipment.ShipmentStatusId = Shipmentpdate.ShipmentStatusId;
                shipment.TrackingNumber = Shipmentpdate.TrackingNumber;
                shipment.MovedDate = Shipmentpdate.MovedDate;
                shipment.ProccedDate = Shipmentpdate.ProccedDate;
              //  shipment.AreaId = Shipmentpdate.AreaId;
             //   shipment.ShippingId = Shipmentpdate.ShippingId;
            //    shipment.BackupId = Shipmentpdate.BackupId;
                shipment.PaymentStatus = Shipmentpdate.PaymentStatus;
                shipment.Products = Shipmentpdate.Products;
                shipment.Reciver = Shipmentpdate.Reciver;
               // shipment.TotalProductsPrice = Shipmentpdate.TotalProductsPrice;
             //   shipment.TotalPrice = Shipmentpdate.TotalPrice;
              //  shipment.ShippingPrice = Shipmentpdate.ShippingPrice;
              //  shipment.TotalWight = Shipmentpdate.TotalWight;
                _db.Shipments.Update(shipment);
                await _db.SaveChangesAsync();
                return shipment;
        }
    }
}
