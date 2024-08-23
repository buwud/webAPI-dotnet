using Application.Interfaces;
using Core.Entities;
using Dapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace CustomerIntegrationTests
{
    public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly WebApplicationFactory<Program> _factory;

        public ApiTests( WebApplicationFactory<Program> factory )
        {
            _factory = factory;
            _customerRepository = factory.Services.GetRequiredService<ICustomerRepository>();
        }


        private void SeedTestData()
        {
            using ( var connection = new SqlConnection("server=(LocalDB)\\MSSQLLocalDB;database=CustomerDB;integrated security=true") )
            {
                connection.Open();
                var sql = "INSERT INTO Customers (Name, Surname, Email, Phone, CreatedAt, UpdatedAt) VALUES ('John', 'Doe', 'john.doe@example.com', '123-456-7890', @CreatedAt, @UpdatedAt)";
                connection.Execute(sql, new { CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            }
        }
        //helper method to clean db
        private void CleanTestData()
        {
            using ( var connection = new SqlConnection("server=(LocalDB)\\MSSQLLocalDB;database=CustomerDB;integrated security=true") )
            {
                connection.Open();
                var sql = "DELETE FROM Customers";
                connection.Execute(sql);
            }
        }
        [Fact]
        public async Task PostCustomer_CreatesCustomer()
        {
            // Arrange
            var customer = new CustomerEntity
            {
                Name = "Jane",
                Surname = "Doe",
                Email = "jane.doe@example.com",
                Phone = "098-765-4321",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Act
            var id = await _customerRepository.AddAsync(customer); // Repository metodunu kullan

            // Assert
            var addedCustomer = await _customerRepository.GetByIdAsync(id);

            addedCustomer.Should().NotBeNull();
            addedCustomer.Name.Should().Be("Jane");
            addedCustomer.Surname.Should().Be("Doe");

            // Cleanup
            CleanTestData();
        }

        //IN MEMORY TEST YAPILACAK
    }
}
