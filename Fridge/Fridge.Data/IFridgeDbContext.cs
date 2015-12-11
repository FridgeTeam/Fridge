using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Fridge.Data
{
    public interface IFridgeDbContext
    {
        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}