using ShippingSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DataAccess.Repository.IRepositories.IBaseRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperity = null);
        Task<T> GetFirstOrDefualtAsync(Expression<Func<T, bool>> filter, string? includeProperity = null, bool tracked = true);
        Task<T> AddAsync(T identity);
        Task<T> removeAsync(T identity);
        void removerange(IEnumerable<T> identity);
    }
}
