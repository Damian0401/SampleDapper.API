using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Persistance.DataAccess
{
    public class DataContext
    {
        private readonly string _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
