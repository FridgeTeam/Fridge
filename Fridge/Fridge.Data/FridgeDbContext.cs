namespace Fridge.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Migrations;
    using Models;
    using Models.Social;

    public class FridgeDbContext : IdentityDbContext<User>, IFridgeDbContext
    {
        public FridgeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FridgeDbContext, Configuration>());
        }

        public static FridgeDbContext Create()
        {
            return new FridgeDbContext();
        }

        public virtual IDbSet<UserSession> UserSessions { get; }

        public virtual IDbSet<Category> Categories { get; }

        public virtual IDbSet<Ingredient> Ingredients { get; }

        public virtual IDbSet<PreparationStep> PreparationSteps { get; }

        public virtual IDbSet<Recipe> Recipes { get; }

        public virtual IDbSet<Unit> Units { get; }

        public virtual IDbSet<Comment> Comments { get; }

        public virtual IDbSet<Rating> Ratings { get; }

        IDbSet<T> IFridgeDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Ratings)
                .WithRequired(r => r.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
              .HasMany(u => u.Comments)
              .WithRequired(c => c.User)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipe>()
              .HasMany(recipe => recipe.Ratings)
              .WithRequired(rating => rating.Recipe)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
            .HasMany(comment => comment.Ratings)
            .WithRequired(rating => rating.Comment)
            .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
