using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IEntitiesRepository;
using ShippingSystem.DataAccess.Repository.Repositories.BaseRepository;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Service.ImagesService;

namespace ShippingSystem.DataAccess.Repository.Repositories.EntitiesRepository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _db;
        public ClientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Client> UpdateClientAsync(Client client, ClientUpdateDto clientupdate)
        {
          
                client.Name = clientupdate.Name;
                client.City = clientupdate.City;
                client.Email = clientupdate.Email;
                client.PhoneNumber = clientupdate.PhoneNumber;
                client.UserName = clientupdate.UserName;
                client.PostalCode = clientupdate.PostalCode;
                client.CompanyName = clientupdate.CompanyName;
                     client.Logo = clientupdate.Logo;
                _db.Clients.Update(client); 
                await _db.SaveChangesAsync();
                return client;
        
        }
    }
}
