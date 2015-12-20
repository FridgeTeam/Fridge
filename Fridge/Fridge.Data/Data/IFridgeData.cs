namespace Fridge.Data.Data
{
    using Models.Social;
    using Models;
    using Repositories;
    using System;

    public interface IFridgeData : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<UserSession> UserSessions { get; }

        IRepository<Category> Categories { get; }

        IRepository<Ingredient> Ingredients { get; }

        IRepository<PreparationStep> PreparationSteps { get; }

        IRepository<Recipe> Recipes { get; }

        IRepository<Unit> Units { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Rating> Ratings { get; }

        int SaveChanges();
    }
}
