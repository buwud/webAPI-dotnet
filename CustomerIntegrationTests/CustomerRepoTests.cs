using Application.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CustomerIntegrationTests
{
    public class CustomerRepoTests
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepoTests()
        {
            var config = new ConfigurationBuilder().Build();
            var context=new DapperContext(config);
            _customerRepository = new CustomerRepository(context);
        }

        //crud tests






        public static void SeedInMemoryData( IDbConnection connection )
        {
            using ( var command = connection.CreateCommand() )
            {
                command.CommandText = @"
            INSERT INTO Customers (Name, Surname, Email, Phone, CreatedAt, UpdatedAt) 
            VALUES 
            ('buwu', 'duran', 'buwu@gmail.com', '123-456-7890', '2024-01-01 12:00:00', '2024-01-01 12:00:00'),
            ('Jane', 'Smith', 'jane.smith@example.com', '098-765-4321', '2024-02-01 12:00:00', '2024-02-01 12:00:00');
        ";
                command.ExecuteNonQuery();
            }
        }
    }
}
