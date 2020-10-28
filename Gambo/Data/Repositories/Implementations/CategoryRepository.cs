using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        #region DB
        public CategoryRepository(ShopDbContext context) : base(context) { }

        private ShopDbContext _context { get { return Context as ShopDbContext; } }
        #endregion

        #region Linq
        public async Task<IEnumerable<Category>> GetAllOrderedAsync()
        {
            return await _context.Categories
                .Where(c => c.Status == true)
                .OrderBy(c => c.OrderBy)
                .ToListAsync();
        }
        #endregion
    }
}
