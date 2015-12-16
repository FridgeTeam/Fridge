namespace Fridge.Data.Data
{
    using Models.Social;
    using Models;
    using Repositories;

    public interface IFridgeData
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
