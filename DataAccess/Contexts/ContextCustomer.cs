using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts
{
    public class ContextCustomer : DbContext
    {
        public string getConnectionString()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("CustomerDb");
        }
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            string connection = getConnectionString();

            optionsBuilder.UseSqlServer(connection);
        }
        public DbSet<Customer> Customers { get; set; }

    }
}
