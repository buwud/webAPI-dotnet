using Dapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Application.Queries
{
    public class GetAllCustomersQuery : IRequest<IList<Customer>>
    {
        private readonly IConfiguration _configuration;
        public GetAllCustomersQuery( IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public async Task<IList<Customer>> Handle( CancellationToken cancellationToken )
        {
            var sql = "SELECT * FROM Customers";
            using ( var connection = new SqlConnection(_configuration.GetConnectionString("CustomerDB")) )
            {
                connection.Open();
                var result = await connection.QueryAsync<Customer>(sql);
                return result.ToList();
            }
        }
    }
}
