using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DapperContext : IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    private readonly IDbConnection _inMemoryConnection;

    // Constructor for production use
    public DapperContext( IConfiguration configuration )
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("CustomerDB");
    }

    // Constructor for testing with an in-memory database
    public DapperContext( IDbConnection inMemoryConnection )
    {
        _inMemoryConnection = inMemoryConnection;
    }

    public IDbConnection CreateConnection()
    {
        if ( _inMemoryConnection != null )
        {
            return _inMemoryConnection;
        }
        return new SqlConnection(_connectionString);
    }

    public void Dispose()
    {
        _inMemoryConnection?.Dispose();
    }

    // Extension class for in-memory connection
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
        public static void CreateTables( IDbConnection connection )
        {
            using ( var command = connection.CreateCommand() )
            {
                command.CommandText = @"
                CREATE TABLE  Customers (
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
        }
        public static void SeedInMemoryData( IDbConnection connection )
        {
            using ( var command = connection.CreateCommand() )
            {
                command.CommandText = @"
                INSERT INTO Customers (Name, Surname, Email, Phone, CreatedAt, UpdatedAt)
                VALUES 
                ('John', 'Doe', 'john.doe@example.com', '123-4567', '2024-01-01', '2024-01-01'),
                ('Jane', 'Smith', 'jane.smith@example.com', '987-6543', '2024-01-02', '2024-01-02'),
                ('Alice', 'Johnson', 'alice.johnson@example.com', '555-5555', '2024-01-03', '2024-01-03');
            ";
                command.ExecuteNonQuery();
            }
        }
    }
}
