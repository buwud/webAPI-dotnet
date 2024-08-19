using Bogus;
using Core.Entities;
using Microsoft.Extensions.Configuration;

public class SharedDatabaseFixture : IDisposable
{
    private static readonly object _lock = new object();
    private static bool _databaseInitialized;
    public DapperContext DapperContext;
    public List<CustomerEntity> Customers = new List<CustomerEntity>();

    public SharedDatabaseFixture(DapperContext dapperContext)
    {
        DapperContext = dapperContext;
        Seed();
    }

    private void Seed()
    {
        lock ( _lock )
        {
            if ( !_databaseInitialized )
            {
                using ( var conn = DapperContext.CreateConnection() )
                {
                    conn.Open();
                    // Clear existing data
                    var command = conn.CreateCommand();
                    command.CommandText = "DELETE FROM Customers";
                    command.ExecuteNonQuery();

                    // Seed new data
                    SeedData();

                    _databaseInitialized = true;
                }
            }
        }
    }

    private void SeedData()
    {
        var customerIds = 1;
        var fakeCustomers = new Faker<CustomerEntity>()
            .RuleFor(x => x.Id, f => customerIds++)
            .RuleFor(x => x.Name, f => $"Customer {customerIds}")
            .RuleFor(x => x.Surname, f => $"Surname {customerIds}")
            .RuleFor(x => x.Email, f => $"Email {customerIds}")
            .RuleFor(x => x.Phone, f => $"Phone {customerIds}")
            .RuleFor(x => x.CreatedAt, f => DateTime.UtcNow)
            .RuleFor(x => x.UpdatedAt, f => DateTime.UtcNow)
            .Generate(10);

        using ( var conn = DapperContext.CreateConnection() )
        {
            conn.Open();
            foreach ( var customer in fakeCustomers )
            {
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO Customers (Name, Surname, Email, Phone, CreatedAt, UpdatedAt) VALUES (@Name, @Surname, @Email, @Phone, @CreatedAt, @UpdatedAt);";
                command.ExecuteNonQuery();
            }
        }

        Customers.AddRange(fakeCustomers);
    }

    public void Dispose() => DapperContext?.Dispose();
}
