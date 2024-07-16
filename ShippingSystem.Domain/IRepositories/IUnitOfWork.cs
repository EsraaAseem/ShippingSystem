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

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
