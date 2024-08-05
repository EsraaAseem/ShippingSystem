using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Services
{
    public class VehicleServiceQuery : IVehicleServiceQuery
    {
        private readonly ShippingSystemContext _context;
        public VehicleServiceQuery(ShippingSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }
    }
}
