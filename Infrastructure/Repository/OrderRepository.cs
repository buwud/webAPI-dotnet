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

        public async Task<IEnumerable<OrderEntity>> GetAllAsync()
        {
            var sql = "SELECT * FROM Orders;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.QueryAsync<OrderEntity>(sql);
                return result;
            }
        }

        public async Task<OrderEntity> GetByIdAsync( int id )
        {
            var sql = "SELECT * FROM Orders WHERE Id = @Id;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<OrderEntity>(sql, new { Id = id });
                if ( result == null )
                {
                    throw new Exception("Order not found");
                }
                return result;
            }
        }

        public async Task<int> UpdateAsync( OrderEntity entity )
        {
            entity.UpdatedAt = DateTime.Now;
            var sql = "UPDATE Orders SET Name = @Name, Status = @Status, Address = @Address, Note = @Note, CustomerId = @CustomerId WHERE Id = @Id;";
            using ( var connection = _context.CreateConnection() )
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
