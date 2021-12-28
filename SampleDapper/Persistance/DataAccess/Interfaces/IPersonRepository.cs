using Domain.Models;

namespace Persistance.DataAccess.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person, int>
    {
    }
}
