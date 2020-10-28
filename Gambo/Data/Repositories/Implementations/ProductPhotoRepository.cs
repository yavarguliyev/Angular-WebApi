using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class ProductPhotoRepository : Repository<ProductPhoto>, IProductPhotoRepository
    {
        #region DB
        public ProductPhotoRepository(ShopDbContext context) : base(context) { }

        private ShopDbContext _context { get { return Context as ShopDbContext; } }
        #endregion

        #region Linq

        #endregion
    }
}