namespace Fridge.Data.Repositories
{
    using System.Linq;
    using Models.Contracts;

    public class PositionableRepository<T> : Repository<T>, IRepository<T> where T : class, IPositionable
    {
        public PositionableRepository(IFridgeDbContext context) : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().OrderBy(x => x.Position);
        }
    }
}
