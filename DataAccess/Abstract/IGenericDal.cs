using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstract
{
    public interface IGenericDal<T> where T : class, new()
    {
        T Insert( T t );
        T Delete( T t );
        T Update( T t );
        T? GetById( int id );
        List<T> GetListAll();
    }
}
