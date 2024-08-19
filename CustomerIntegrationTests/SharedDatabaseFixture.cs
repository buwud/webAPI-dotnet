using Bogus;
using Core.Entities;
using Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace CustomerIntegrationTests
{
    public class SharedDatabaseFixture : IDisposable
    {

        private static readonly object _lock = new object();
        private static bool _databaseInitialized;
        private string _databaseName = "CustomerDB";
        public DbConnection Connection { get; }
        public DapperContext DapperContext { get; }
        public List<CustomerEntity> Customers { get; private set; } = new List<CustomerEntity>();

        public SharedDatabaseFixture( DapperContext dapperContext )
        {
            Connection = new SqlConnection("server=(LocalDB)\\MSSQLLocalDB;database=CustomerDB;integrated security=true");
            DapperContext = new DapperContext(new ConfigurationBuilder().Build());
            Seed();
        }

        private void Seed()
        {
            lock ( _lock )
            {
                if ( _databaseInitialized )
                {
                    using ( var conn = DapperContext.CreateConnection() )
                    {
                        conn.Open();
                        conn.ChangeDatabase(_databaseName);

                        //clear all data
                        var command = conn.CreateCommand();
                        command.CommandText = "DELETE FROM Customers";
                        command.ExecuteNonQuery();

                        //seed new datas
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
                    command.CommandText = $"INSERT INTO Customers (Id, Name, Surname, Email, Phone, CreatedAt, UpdatedAt) VALUES ({customer.Id},@{customer.Name}, {customer.Surname}, {customer.Email}, {customer.Phone}, {customer.CreatedAt}, {customer.UpdatedAt})";
                    command.ExecuteNonQuery();
                }
            }
            Customers.AddRange(fakeCustomers);
        }
        public void Dispose() => Connection.Dispose();
    }
}
