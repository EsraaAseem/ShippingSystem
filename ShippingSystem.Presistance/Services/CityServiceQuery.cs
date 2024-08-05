using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Services
{
    public class CityServiceQuery : ICityQueryService
    {
        private readonly ShippingSystemContext _context;
        public CityServiceQuery(ShippingSystemContext context)
        {
            _context = context;
        }

        public IQueryable<City> GetCities()
        {
            return _context.Cities.AsQueryable();
        }

        public async Task<City?> GetCityAsync(string cityName)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Name == cityName);
        }
    }
}
