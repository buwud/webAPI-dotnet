using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Application.Features.Commands.Customer
{
    public class CreateOrUpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public class CreateOrUpdateCustomerCommandHandler : IRequestHandler<CreateOrUpdateCustomerCommand, int>
        {
            private readonly IConfiguration _configuration;
            public CreateOrUpdateCustomerCommandHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<int> Handle(CreateOrUpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                if (command.Id > 0)
                {
                    var sql = "UPDATE Customers SET Name = @Name, Surname = @Surname, Email = @Email, Phone = @Phone WHERE Id = @Id";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("CustomerDB")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, command);
                        return result;
                    }
                }
                else
                {
                    var sql = "INSERT INTO Customers (Name, Surname, Email, Phone) VALUES (@Name, @Surname, @Email, @Phone)";
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("CustomerDB")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { ClientName = command.Name });
                        return result;
                    }
                }
            }
        }
    }
}
