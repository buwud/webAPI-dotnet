using Domain;

namespace Infrastructure.Abstract
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<int> Insert( Customer customer );
        Task<int> Update( Customer customer );
        Task<int> Delete( int id );
        Task<T?> GetById( int id );
        Task<IEnumerable<T>> GetListAll();
    }
}
