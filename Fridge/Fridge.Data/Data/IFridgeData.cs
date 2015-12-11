namespace Fridge.Data.Data
{
    using Models;
    using Repositories;

    public interface IFridgeData
    {
        IRepository<User> Users { get; }
 
        int SaveChanges();
    }
}
