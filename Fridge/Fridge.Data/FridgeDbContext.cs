using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using Fridge.Data.Migrations;
using Fridge.Models;

namespace Fridge.Data
{
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

        public IDbSet<UserSession> UserSessions { get; set; }

        IDbSet<T> IFridgeDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}
