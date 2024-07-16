using Microsoft.EntityFrameworkCore;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Presistance.Data;


namespace ShippingSystem.Presistance.Repostiories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShippingSystemContext _context;
        public DbSet<T> dbSet;

        public Repository(ShippingSystemContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public Task Add(T entity)
        {
            dbSet.Add(entity);
            return Task.CompletedTask;
        }
        public Task Remove(T entity)
        {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
