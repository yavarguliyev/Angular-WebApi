using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Data.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        #region DB
        public ProductRepository(ShopDbContext context) : base(context) { }

        private ShopDbContext _context { get { return Context as ShopDbContext; } }
        #endregion

        #region Linq
        public async Task<IEnumerable<Product>> GetFeaturedProductsByBranchId(long branchId)
        {
            return await _context.Products
                .Include(p => p.Unit)
                .Include(p => p.ProductPhotos)
                .Include(p => p.DiscountProducts).ThenInclude(p => p.Discount)
                .IncludeFilter(p => p.DiscountProducts.FirstOrDefault(d => d.Discount.Status
                               && d.Discount.StartDate <= DateTime.Now
                               && d.Discount.EndDate >= DateTime.Now))
                .IncludeFilter(p => p.Stocks.FirstOrDefault(s => s.BranchId == branchId))
                .Where(p => p.Status == true && p.IsFeatured == true)
                .Where(p => p.Stocks.Any(s => s.BranchId == branchId && s.Quanity > 0))
                .OrderByDescending(p => p.AddedData)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetNewProductsByBranchId(long branchId)
        {
            return await _context.Products
                .Include(p => p.Unit)
                .Include(p => p.ProductPhotos)
                .Include(p => p.DiscountProducts).ThenInclude(p => p.Discount)
                .IncludeFilter(p => p.DiscountProducts.FirstOrDefault(d => d.Discount.Status
                               && d.Discount.StartDate <= DateTime.Now
                               && d.Discount.EndDate >= DateTime.Now))
                .IncludeFilter(p => p.Stocks.FirstOrDefault(s => s.BranchId == branchId))
                .Where(p => p.Status == true && p.IsNew == true)
                .Where(p => p.Stocks.Any(s => s.BranchId == branchId && s.Quanity > 0))
                .OrderByDescending(p => p.AddedData)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetNewProductsByBranchIdAndCategoryId(long branchId, long categoryId, int page)
        {
            return await _context.Products
                 .Include(p => p.Unit)
                 .Include(p => p.ProductPhotos)
                 .Include(p => p.DiscountProducts).ThenInclude(p => p.Discount)
                 .IncludeFilter(p => p.DiscountProducts.FirstOrDefault(d => d.Discount.Status
                                && d.Discount.StartDate <= DateTime.Now
                                && d.Discount.EndDate >= DateTime.Now))
                 .IncludeFilter(p => p.Stocks.FirstOrDefault(s => s.BranchId == branchId))
                 .Where(p => p.Status == true && p.CategoryId == categoryId)
                 .Where(p => p.Stocks.Any(s => s.BranchId == branchId && s.Quanity > 0))
                 .OrderByDescending(p => p.AddedData)
                 .Skip((page - 1) * 12)
                 .Take(12)
                 .ToListAsync();
        }

        public async Task<int> GetNewProductsCountByBranchIdAndCategoryId(long branchId, long categoryId)
        {
            return await _context.Products
                 .IncludeFilter(p => p.Stocks.FirstOrDefault(s => s.BranchId == branchId))
                 .Where(p => p.Status == true && p.CategoryId == categoryId)
                 .Where(p => p.Stocks.Any(s => s.BranchId == branchId && s.Quanity > 0))
                 .CountAsync();
        }

        public async Task<Product> GetProductById(long id, long branchId)
        {
            return await _context.Products
                 .Include(p => p.Unit)
                 .Include(p => p.ProductPhotos)
                 .Include(p => p.DiscountProducts).ThenInclude(p => p.Discount)
                 .IncludeFilter(p => p.DiscountProducts.FirstOrDefault(d => d.Discount.Status
                                && d.Discount.StartDate <= DateTime.Now
                                && d.Discount.EndDate >= DateTime.Now))
                 .IncludeFilter(p => p.Stocks.FirstOrDefault(s => s.BranchId == branchId))
                 .Where(p => p.Status == true && p.Id == id)
                 .Where(p => p.Stocks.Any(s => s.BranchId == branchId && s.Quanity > 0))
                 .FirstOrDefaultAsync();
        }
        #endregion
    }
}