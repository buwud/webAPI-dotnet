using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext( DbContextOptions<CustomerContext> options ) : base(options)
        {
        }
        public string getConnectionString()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();

            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("CustomerDB");
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            string connection = getConnectionString();

            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
