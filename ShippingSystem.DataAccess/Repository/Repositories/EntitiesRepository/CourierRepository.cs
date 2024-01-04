using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.BaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository
{
    public class CourierRepository:Repository<Courier>,ICourierRepository
    {
        private readonly ApplicationDbContext _db;
        public CourierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Courier> UpdateCourierAsync(string Id, CourierUpdateDto courierupdate)
        {
            var courier = await _db.Couriers.FirstOrDefaultAsync(c => c.Id == Id);
            if (courier == null)
                throw new NotFoundException("Client not found");
                courier.Name=courierupdate.Name;
                courier.City=courierupdate.City;
                courier.Email=courierupdate.Email;
                courier.PhoneNumber=courierupdate.PhoneNumber;
                courier.UserName=courierupdate.UserName;
                courier.PostalCode=courierupdate.PostalCode;
                _db.Couriers.Update(courier);
                await _db.SaveChangesAsync();
                return courier;
         
        }
    }
}
