namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class, new()
    {
        T Insert( T entity );
        T Update( T entity );
        T Delete( T entity );
        T? GetById( int id );
        List<T> GetListAll();
    }
}
