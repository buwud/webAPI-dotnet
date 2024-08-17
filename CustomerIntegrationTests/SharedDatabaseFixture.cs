using Bogus;
using Core.Entities;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
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
        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection($"Filename={_databaseName}");
            Seed();
        }
        public CustomerContext CreateContext( DbTransaction? transaction = null )
        {
            var context = new CustomerContext(new DbContextOptionsBuilder<CustomerContext>().UseSqlServer(Connection).Options);
            if ( transaction != null )
            {
                context.Database.UseTransaction(transaction);
            }
            return context;
        }
        private void Seed()
        {
            lock ( _lock )
            {
                if ( _databaseInitialized )
                {
                    using ( var conn = CreateContext() )
                    {
                        conn.Database.EnsureDeleted();
                        conn.Database.EnsureDeleted();


                    }
                }
            }
        }
        private void SeedData( CustomerContext context )
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
            context.AddRange(fakeCustomers);
            context.SaveChanges();
        }
        public void Dispose() => Connection.Dispose();
    }
}
