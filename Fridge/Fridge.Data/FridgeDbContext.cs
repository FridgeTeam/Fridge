using System;
using System.Data.Entity;
using Fridge.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fridge.Data
{
    public class FridgeDbContext : IdentityDbContext<User>, IFridgeDbContext
    {
        public FridgeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static FridgeDbContext Create()
        {
            return new FridgeDbContext();
        }

        IDbSet<T> IFridgeDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}
