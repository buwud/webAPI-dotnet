using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext( DbContextOptions<CustomerContext> options ) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
