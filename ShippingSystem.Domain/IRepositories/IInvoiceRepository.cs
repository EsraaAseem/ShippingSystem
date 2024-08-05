using ShippingSystem.Domain.Models;


namespace ShippingSystem.Domain.IRepositories
{
    public interface IInvoiceRepository:IRepository<Invoice>
    {
        Task<Invoice> GetInvoiceAsync(Guid id );
    }
}
