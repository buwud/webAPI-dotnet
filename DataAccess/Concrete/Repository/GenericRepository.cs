using DataAccess.Abstract;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repository
{
    public class GenericRepository<TEntity, TContext> : IGenericDal<TEntity>
        where TEntity : class, new()
        where TContext : ContextCustomer, new()
    {
        public TEntity Delete( TEntity entity )
        {
            using ( var context = new TContext() )
            {
                TEntity getEntity = context.Remove(entity).Entity;
                var deletedEntity = context.Entry(getEntity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                return getEntity;
            }
        }
        public TEntity GetById( int id )
        {
            using ( var context = new TContext() )
            {
                return context.Set<TEntity>().Find(id);
            }
        }
        public List<TEntity> GetListAll()
        {
            using ( var context = new TContext() )
            {
                var entities = context.Set<TEntity>().ToList();
                return entities;
            }
        }

        public TEntity Insert( TEntity entity )
        {
            using ( var context = new TContext() )
            {
                TEntity getEntity = context.Add(entity).Entity;
                var addedEntity = context.Entry(getEntity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return getEntity;
            }
        }

        public TEntity Update( TEntity entity )
        {
            using ( var context = new TContext() )
            {
                TEntity getEntity = context.Update(entity).Entity;
                var updatedEntity = context.Entry(getEntity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return getEntity;
            }
        }
    }
}
