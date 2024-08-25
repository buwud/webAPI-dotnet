using Application.Interfaces;
using Core.Entities;
using Infrastructure.Repository;
using System.Data;

namespace CustomerIntegrationTests
{
    public class CustomerRepoTests
    {
        private readonly ICustomerRepository _repository;
        private readonly IDbConnection _inMemoryConnection;

        public CustomerRepoTests()
        {
            // Create in-memory SQLite connection
            _inMemoryConnection = DapperContext.DapperContextExtensions.CreateInMemoryConnection();

            // Create the context with the in-memory connection
            var context = new DapperContext(_inMemoryConnection);
            _repository = new CustomerRepository(context);

            // Ensure the Customers table is created
            DapperContext.DapperContextExtensions.CreateTables(_inMemoryConnection);

            // Optionally seed the table with initial data
            DapperContext.DapperContextExtensions.SeedInMemoryData(_inMemoryConnection);
        }

        [Fact]
        public async Task CreateCustomerAsync_ShouldAddNewCustomer()
        {
            var newCustomer = new CustomerEntity
            {
                Name = "Alice",
                Surname = "Johnson",
                Email = "alice.johnson@example.com",
                Phone = "555-5555",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var customerId = await _repository.AddAsync(newCustomer);

            var createdCustomer = await _repository.GetByIdAsync(customerId);

            Assert.NotNull(createdCustomer);
            Assert.Equal("Alice", createdCustomer.Name);
            Assert.Equal("Johnson", createdCustomer.Surname);
        }
    }


}
