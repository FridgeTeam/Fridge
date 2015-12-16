namespace Fridge.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;
    using Models.Social;

    public interface IFridgeDbContext
    {
        IDbSet<User> Users { set; }

        IDbSet<UserSession> UserSessions { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Ingredient> Ingredients { get; }

        IDbSet<PreparationStep> PreparationSteps { get; }

        IDbSet<Recipe> Recipes { get; }

        IDbSet<Unit> Units { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Rating> Ratings { get; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}