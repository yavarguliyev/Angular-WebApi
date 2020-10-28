using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        #region DB
        public UnitRepository(ShopDbContext context) : base(context) { }

        private ShopDbContext _context { get { return Context as ShopDbContext; } }
        #endregion

        #region Linq

        #endregion
    }
}