using Dapper;
using Domain;
using Infrastructure.Abstract;
using Infrastructure.Contexts;

namespace Infrastructure.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository( DapperContext context )
        {
            _context = context;
        }

        public async Task<int> Create( Customer customer )
        {
            var sql = "INSERT INTO Customers (Name, Surname, Email, Phone) VALUES (@Name, @Surname, @Email, @Phone)";
            using ( var connection = _context.CreateConnection() )
            {
                return await connection.ExecuteAsync(sql, customer);
            }
        }

        public async Task<int> Delete( int id )
        {
            var sql = "DELETE FROM Customers WHERE Id = @Id";
            using ( var connection = _context.CreateConnection() )
            {
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<Customer> GetById( int id )
        {
            var sql = "SELECT * FROM Customers WHERE Id = @Id";
            using ( var connection = _context.CreateConnection() )
            {
                return await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Customer>> GetListAll()
        {
            var sql = "SELECT * FROM Customers";
            using ( var connection = _context.CreateConnection() )
            {
                return await connection.QueryAsync<Customer>(sql);
            }
        }

        public async Task<int> Update( Customer customer )
        {
            var sql = "UPDATE Customers SET Name = @Name, Surname = @Surname, Email = @Email, Phone = @Phone WHERE Id = @Id";
            using ( var connection = _context.CreateConnection() )
            {
                return await connection.ExecuteAsync(sql, customer);
            }
        }
    }
}
