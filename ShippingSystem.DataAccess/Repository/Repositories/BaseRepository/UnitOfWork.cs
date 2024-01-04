using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository;
using ShippingSystem.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Repository.Repositories.BaseRepository
{
    public class UnitOfWork:IUnitOfWork
    {
        private  ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Clients = new ClientRepository(db);
            Couriers=new CourierRepository(db);
            Employees=new EmployeeRepository(db);
            BackUp=new BackupRepository(db);
            Area=new AreaRepository(db);
            ShipmentStatus= new ShipmentStatusRepository(db);
            DeliveryShipments = new EntitiesRepository.ShippingRepository(db);
            Shipment =new ShipmentRepository(db);
            Vehicles=new VehicleRepository(db);
            BackupStatus = new BackupStatusRepository(db);
            Invoice=new InvoiceRepository(db);
        }
        public IClientRepository Clients { get; private set; }
        public ICourierRepository Couriers { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
       public IBackupRepository BackUp { get; private set; }
        public IAreaRepository Area { get; private set; }
        public IShipmentStatusRepository ShipmentStatus { get; private set; }
        public IRepositories.IEntitiesRepository.IShippingRepository DeliveryShipments { get; private set; }
        public IShipmentRepository Shipment { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }    
        public IBackupStatusRepository BackupStatus { get; private set; }
        public IInvoiceRepository Invoice{ get; private set; }

        public void SaveAsync()
        {
            _db.SaveChangesAsync();
        }

    }
}
