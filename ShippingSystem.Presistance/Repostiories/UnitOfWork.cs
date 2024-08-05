using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Presistance.Data;


namespace ShippingSystem.Presistance.Repostiories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShippingSystemContext _context;
        public UnitOfWork(ShippingSystemContext context)
        {
            _context = context;
            ClientAddRequestRepository = new ClientAddRequestRepository(_context);
            VehicleRepository = new VehicleRepository(_context);
            BeackupRepository = new BeackupRepository(_context);
            GovernorateRepository = new GovernorateRepository(_context);
            CityRepository = new CityRepository(_context);
            ShipmentRepository = new ShipmentRepository(_context);
            ShippingRepository = new ShippingRepository(_context);
            ShipmentStatusRepository = new ShipmentStatusRepository(_context);
            InvoiceRepository=new InvoiceRepository(_context);
            InvoiceItemsRepository = new InvoiceItemsRepository(_context);
            DeliveryFeesRepository=new DeliveryFeesRepository(_context);
            ClientRepository = new ClientRepository(_context);
            EmployeeRepository = new EmployeeRepository(_context);
            RepresentativeRepository = new RepresentativeRepository(_context);
        }

        public IClientAddRequestRepository ClientAddRequestRepository { get; private set; }
        public IVehicleRepository VehicleRepository { get; private set; }
        public IBeackupRepository BeackupRepository { get; private set; }
        public IGovernorateRepository GovernorateRepository { get; private set; }
        public ICityRepository CityRepository { get; private set; }
        public IShipmentRepository ShipmentRepository { get; private set; }
        public IShippingRepository ShippingRepository { get; private set; }
        public IShipmentStatusRepository ShipmentStatusRepository { get; private set; }
        public IInvoiceRepository InvoiceRepository { get; private set; }
        public IInvoiceItemsRepository InvoiceItemsRepository { get; private set; }
        public IDeliveryFeesRepository DeliveryFeesRepository { get; private set; }
        public IClientRepository ClientRepository { get; private set; }
       public IRepresentativeRepository RepresentativeRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }


        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync();
        }
    }
}
