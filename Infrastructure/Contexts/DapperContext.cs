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
}
