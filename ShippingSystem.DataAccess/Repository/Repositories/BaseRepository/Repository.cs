using Microsoft.EntityFrameworkCore;
using ShippingSystem.DataAccess.Data;
using ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository;
using ShippingSystem.Utility;
using System.Linq.Expressions;

namespace ShippingSystem.DataAccess.Repository.Repositories.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext _db;
        public DbSet<T> dbSet;
        private readonly BaseResponse _response;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
            _response = new();
        }


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperity = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperity != null)
            {
                foreach (var properity in includeProperity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(properity);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefualtAsync(Expression<Func<T, bool>> filter, string? includeProperity = null, bool tracked = true)
        {
            IQueryable<T> query;
            if (tracked == true)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperity != null)
            {
                foreach (var properity in includeProperity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(properity);
                }
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task<T> removeAsync(T Entity)
        {
            var del = _db.Remove(Entity);
            return del.Entity;
        }


        public void removerange(IEnumerable<T> Entity)
        {
            _db.RemoveRange(Entity);
        }

        public async Task<T> AddAsync(T Entity)
        {
            var entity = await _db.AddAsync(Entity);
            return entity.Entity;

        }

        
    }
}
