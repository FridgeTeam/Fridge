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

        IRepository<IngredientRecipe> IngredientRecipes { get; }

        IRepository<PreparationStep> PreparationSteps { get; }

        IRepository<Recipe> Recipes { get; }

        IRepository<Unit> Units { get; }

        IRepository<Ingredient> Ingredients { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Tag> Tags { get; }

        IRepository<TagGroup> TagGroups { get; }

        int SaveChanges();
    }
}
