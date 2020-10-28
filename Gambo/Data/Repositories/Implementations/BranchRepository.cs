using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        #region DB
        public BranchRepository(ShopDbContext context) : base(context) { }

        private ShopDbContext _context { get { return Context as ShopDbContext; } }
        #endregion

        #region Linq

        #endregion
    }
}