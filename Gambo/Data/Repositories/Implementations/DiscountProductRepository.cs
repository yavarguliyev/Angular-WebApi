using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class DiscountProductRepository : Repository<DiscountProduct>, IDiscountProductRepository
    {
        #region DB
        public DiscountProductRepository(ShopDbContext context) : base(context) { }

        private ShopDbContext _context { get { return Context as ShopDbContext; } }
        #endregion

        #region Linq

        #endregion
    }
}