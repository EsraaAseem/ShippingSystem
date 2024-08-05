using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Presistance.Repostiories
{
    public class CityRepository:Repository<City>, ICityRepository
    {

        private ShippingSystemContext _context;
        public CityRepository(ShippingSystemContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckCity(string govern, string city)
        {
            return _context.Cities.Any(c => c.GovernorateName.ToLower() == govern.ToLower() &&
                                   c.Name.ToLower() == city.ToLower());
        }

        public async Task<City ?> GetCityAsync(string cityName)
        {
            return await _context.Cities.FirstOrDefaultAsync(b => b.Name == cityName);
        }
    }
}
