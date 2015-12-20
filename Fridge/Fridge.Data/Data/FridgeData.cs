namespace Fridge.Data.Data
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;
    using Models.Social;
    using Models.Contracts;

    public class FridgeData : IFridgeData
    {
        private IFridgeDbContext context;
        private IDictionary<Type, object> repositories;

        public FridgeData()
        {
            this.context = new FridgeDbContext();
        }

        public FridgeData(IFridgeDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IFridgeDbContext Context
        {
            get { return this.context; }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<UserSession> UserSessions
        {
            get { return this.GetRepository<UserSession>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetPositionableRepository<Category>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Ingredient> Ingredients
        {
            get { return this.GetPositionableRepository<Ingredient>(); }
        }

        public IRepository<PreparationStep> PreparationSteps
        {
            get { return this.GetRepository<PreparationStep>(); }
        }

        public IRepository<Rating> Ratings
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IRepository<Recipe> Recipes
        {
            get { return this.GetRepository<Recipe>(); }
        }

        public IRepository<Unit> Units
        {
            get { return this.GetRepository<Unit>(); }
        }


        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            Type modelType = typeof(T);
            if (!this.repositories.ContainsKey(modelType))
            {
                Type repositoryType = typeof(Repository<T>);
                this.repositories.Add(modelType, Activator.CreateInstance(repositoryType, this.context));
            }

            return (IRepository<T>)this.repositories[modelType];
        }

        private IRepository<T> GetPositionableRepository<T>() where T : class, IPositionable
        {
            Type modelType = typeof(T);
            if (!this.repositories.ContainsKey(modelType))
            {
                Type type = typeof(PositionableRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
