using System;
 
namespace ShippingSystem.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        IClientAddRequestRepository ClientAddRequestRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IBeackupRepository BeackupRepository { get; }
        IGovernorateRepository GovernorateRepository { get; }
        ICityRepository CityRepository { get; }
        IShipmentRepository ShipmentRepository { get; }
        IShippingRepository ShippingRepository { get;}
        IShipmentStatusRepository ShipmentStatusRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceItemsRepository InvoiceItemsRepository { get; }
        IDeliveryFeesRepository DeliveryFeesRepository { get; }
        IClientRepository ClientRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IRepresentativeRepository RepresentativeRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
