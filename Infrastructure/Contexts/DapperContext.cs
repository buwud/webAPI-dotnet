using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DapperContext : IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext( IConfiguration configuration )
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("CustomerDB");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public void Dispose()
    {
        // Dispose logic if needed
    }
    public static class DapperContextExtensions
    {
        public static IDbConnection CreateInMemoryConnection()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            using ( var command = connection.CreateCommand() )
            {
                command.CommandText = @"
                CREATE TABLE Customers (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Surname TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Phone TEXT NOT NULL,
                    CreatedAt TEXT NOT NULL,
                    UpdatedAt TEXT NOT NULL
                );
            ";
                command.ExecuteNonQuery();
            }

            return connection;
        }
    }

}
