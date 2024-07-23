using Application.Interfaces;
using Core.Entities;
using Dapper;
using Infrastructure.Contexts;

namespace Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository( DapperContext context )
        {
            _context = context;
        }

        public async Task<int> AddAsync( CustomerEntity entity )
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            var sql = "INSERT INTO Customers (Name, Surname, Email, Phone, CreatedAt, UpdatedAt) VALUES (@Name, @Surname, @Email, @Phone, @CreatedAt, @UpdatedAt);";

            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync( int id )
        {
            var sql = "DELETE FROM Customers WHERE Id = @Id;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            var sql = "SELECT * FROM Customers;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.QueryAsync<CustomerEntity>(sql);
                return result;
            }
        }

        public async Task<CustomerEntity> GetByIdAsync( int id )
        {
            var sql = "SELECT * FROM Customers WHERE Id = @Id;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CustomerEntity>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync( CustomerEntity entity )
        {
            entity.UpdatedAt = DateTime.Now;
            var sql = "UPDATE Customers SET Name = @Name, Surname = @Surname, Email = @Email, Phone = @Phone WHERE Id = @Id;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
