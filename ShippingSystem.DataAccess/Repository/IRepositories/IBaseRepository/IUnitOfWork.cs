using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository
{
    public interface IUnitOfWork
    {
        IClientRepository Clients { get; }
        ICourierRepository Couriers { get; }
        IEmployeeRepository Employees { get; }
        IBackupRepository BackUp { get; }
        IAreaRepository Area { get; }
        IShipmentStatusRepository ShipmentStatus { get; }
        IShippingRepository DeliveryShipments { get; }
        IShipmentRepository Shipment { get; }
        IVehicleRepository Vehicles { get; }
        IBackupStatusRepository BackupStatus { get; }
        IInvoiceRepository Invoice { get; }
        public void SaveAsync();
    }
}
