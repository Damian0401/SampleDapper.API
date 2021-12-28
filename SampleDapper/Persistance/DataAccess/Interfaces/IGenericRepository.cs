using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.DataAccess.Interfaces
{
    public interface IGenericRepository<T, U> where T : class
    {
        Task<T> GetByIdAsync(U id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<U> AddAsync(T entity);
        Task<bool> UpdateByIdAsync(U id, T entity);
        Task<bool> DeleteAsync(U id);
    }
}
