using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts
{
    public class ContextCustomer : DbContext
    {
        public ContextCustomer( DbContextOptions<ContextCustomer> options ) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
