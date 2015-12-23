namespace Fridge.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;
    using Models.Social;
 
    public interface IFridgeDbContext : IDisposable
    {
        IDbSet<User> Users { set; }

        IDbSet<UserSession> UserSessions { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<IngredientRecipe> IngredientRecipes { get; }

        IDbSet<PreparationStep> PreparationSteps { get; }

        IDbSet<Recipe> Recipes { get; }

        IDbSet<Unit> Units { get; }

        IDbSet<Ingredient> Ingredients { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Rating> Ratings { get; }

        IDbSet<Tag> Tags { get; }

        IDbSet<TagGroup> TagGroups { get; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}