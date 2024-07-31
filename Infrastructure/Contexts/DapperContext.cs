using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Infrastructure.Contexts
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext( IConfiguration configuration )
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CustomerDB");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
