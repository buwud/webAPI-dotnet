using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Business.Commands.Customer
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
        {
            private readonly IConfiguration _configuration;
            public DeleteCustomerCommandHandler( IConfiguration configuration )
            {
                _configuration = configuration;
            }
            public async Task<int> Handle( DeleteCustomerCommand command, CancellationToken cancellationToken )
            {
                var sql = "DELETE FROM Customers WHERE Id = @Id";
                using ( var connection = new SqlConnection(_configuration.GetConnectionString("CustomerDB")) )
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { ClientID = command.Id });
                    return result;
                }

            }
        }
    }
}
