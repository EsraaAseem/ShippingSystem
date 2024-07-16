using ShippingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Domain.IRepositories
{
    public interface ICityRepository:IRepository<City>
    {
        bool CheckCity(string govern, string city);
    }
}
