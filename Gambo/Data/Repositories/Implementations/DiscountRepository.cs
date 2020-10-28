using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        #region DB
        public DiscountRepository(ShopDbContext context) : base(context) { }

        private ShopDbContext _context { get { return Context as ShopDbContext; } }
        #endregion

        #region Linq

        #endregion
    }
}