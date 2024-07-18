using Dapper;
using Domain;
using Infrastructure.Abstract;
using Infrastructure.Contexts;

namespace DataAccess.Concrete.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository( DapperContext context )
        {
            _context = context;
        }
        public Task<int> Delete( int id )
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetById( int id )
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetListAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert( Customer customer )
        {
            var sql = "INSERT INTO Customers (Name, Surname, Email, Phone) VALUES (@Name, @Surname, @Email, @Phone)";
            using ( var connection = _context.CreateConnection() )
            {
                return await connection.ExecuteAsync(sql, customer);
            }
        }

        public Task<int> Update( Customer customer )
        {
            throw new NotImplementedException();
        }
    }
}
