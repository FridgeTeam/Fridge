namespace Fridge.Data.Data
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

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



        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var modelType = typeof(T);
            if (!this.repositories.ContainsKey(modelType))
            {
                var repositoryType = typeof(Repository<T>);
                this.repositories.Add(modelType, Activator.CreateInstance(repositoryType, this.context));
            }

            return (IRepository<T>)this.repositories[modelType];
        }
    }
}
