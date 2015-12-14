namespace Fridge.Data.Data
{
    using Models;
    using Repositories;

    public interface IFridgeData
    {
        IRepository<User> Users { get; }

        IRepository<UserSession> UserSessions { get; }

        int SaveChanges();
    }
}
