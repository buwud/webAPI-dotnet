using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts
{
    public class CustomerContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CustomerContext( IConfiguration configuration )
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            string connection = _configuration.GetConnectionString("Default");
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
