using Application.Interfaces;
using Core.Entities;
using Dapper;

namespace Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _context;
        public OrderRepository( DapperContext context )
        {
            _context = context;
        }

        public async Task<int> AddAsync( OrderEntity entity )
        {
            var sql = "INSERT INTO Orders (Name, Status, Address, Note, CustomerId) VALUES (@Name, @Status, @Address, @Note, @CustomerId); SELECT SCOPE_IDENTITY();";
            using ( var connection = _context.CreateConnection() )
            {
                var id = await connection.ExecuteScalarAsync<int>(sql, entity);
                return id;
            }
        }

        public async Task<int> DeleteAsync( int id )
        {
            var sql = "DELETE FROM Orders WHERE Id = @Id;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public Task<IEnumerable<OrderEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> GetByIdAsync( int id )
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync( OrderEntity entity )
        {
            throw new NotImplementedException();
        }
    }
}
