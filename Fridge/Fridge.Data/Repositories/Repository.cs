namespace Fridge.Data.Repositories
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T>
        : IRepository<T> where T : class
    {
        public Repository(IFridgeDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IFridgeDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet;
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.All().Where(expression);
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual T Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            return entity;
        }

        public virtual void AddRange(IList<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Add(entity);
            }
        }

        public virtual T Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
        }

        public virtual void DeleteRange(IQueryable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = state;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }
    }
}
