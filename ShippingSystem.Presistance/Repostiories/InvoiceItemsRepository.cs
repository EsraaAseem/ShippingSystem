using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;

namespace ShippingSystem.Presistance.Repostiories
{
    public class InvoiceItemsRepository : Repository<InvoiceItems>, IInvoiceItemsRepository
    {
        public InvoiceItemsRepository(ShippingSystemContext context) : base(context)
        {
        }
    }
}
