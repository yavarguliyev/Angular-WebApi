using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetFeaturedProductsByBranchId(long branchId);
        Task<IEnumerable<Product>> GetNewProductsByBranchId(long branchId);
        Task<IEnumerable<Product>> GetNewProductsByBranchIdAndCategoryId(long branchId, long categoryId, int page);
        Task<int> GetNewProductsCountByBranchIdAndCategoryId(long branchId, long categoryId);
        Task<Product> GetProductById(long id, long branchId);
    }
}