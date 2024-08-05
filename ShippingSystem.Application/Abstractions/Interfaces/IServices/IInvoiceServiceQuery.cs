using ShippingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Application.Abstractions.Interfaces.IServices
{
    public interface IInvoiceServiceQuery
    {
        Task<List<Invoice>> GetInvoices(string? id);
    }
}
