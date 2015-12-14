using Fridge.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Fridge.Data
{
    public interface IFridgeDbContext
    {
        IDbSet<User> Users { set; }

        IDbSet<UserSession> UserSessions { get; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}