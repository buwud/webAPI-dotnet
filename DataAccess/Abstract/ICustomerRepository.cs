using Domain;

namespace Infrastructure.Abstract
{
    public interface ICustomerRepository
    {
        Task<int> Create( CustomerEntity customer );
        Task<int> Update( CustomerEntity customer );
        Task<int> Delete( int id );
        Task<CustomerEntity> GetById( int id );
        Task<IEnumerable<CustomerEntity>> GetListAll();
    }
}
