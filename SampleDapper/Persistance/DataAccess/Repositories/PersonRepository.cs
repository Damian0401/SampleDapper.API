using Dapper;
using Domain.Models;
using Persistance.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Persistance.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Person entity)
        {
            var query = @"
                INSERT INTO Persons
                    (FirstName, LastName, DayOfBirth, Email)
                VALUES
                    (@FirstName, @LastName, @DayOfBirth, @Email)"
                + "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters(entity);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                return id;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = "DELETE FROM Persons WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var rowsAffectedCount = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffectedCount > 0;
            }
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var query = @"SELECT * FROM Persons";

            using (var connection = _context.CreateConnection())
            {
                var persons = await connection.QueryAsync<Person>(query);

                return persons;
            }
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Persons WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var person = await connection.QuerySingleOrDefaultAsync<Person>(query, new { Id = id });

                return person;
            }
        }

        public async Task<bool> UpdateByIdAsync(int id, Person entity)
        {
            var query = @"
                UPDATE 
                    Persons
                SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    DayOfBirth = @DayOfBirth,
                    Email = @Email
                WHERE
                    Id = @Id";

            var parameters = new DynamicParameters(entity);
            parameters.Add("Id", id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var rowsAffectedCount = await connection.ExecuteAsync(query, parameters);

                return rowsAffectedCount > 0;
            }
        }
    }
}
