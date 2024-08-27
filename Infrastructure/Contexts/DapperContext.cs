using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DapperContext : IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    // Constructor for production use
    public DapperContext( IConfiguration configuration, string connectionStringName = "CustomerDB" )
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString(connectionStringName);
    }


    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public void Dispose() { }

}
