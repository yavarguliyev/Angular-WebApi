using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _context;

        private BranchRepository _branchRepository;
        private CategoryRepository _categoryRepository;
        private DiscountRepository _discountRepository;
        private DiscountProductRepository _discountProductRepository;
        private ProductRepository _productRepository;
        private ProductPhotoRepository _productPhotoRepository;
        private StockRepository _stockRepository;
        private UnitRepository _unitRepository;

        public UnitOfWork(ShopDbContext context)
        {
            this._context = context;
        }

        public IBranchRepository Branch => _branchRepository ??= new BranchRepository(_context);
        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_context);
        public IDiscountRepository Discount => _discountRepository ??= new DiscountRepository(_context);
        public IDiscountProductRepository DiscountProduct => _discountProductRepository ??= new DiscountProductRepository(_context);
        public IProductRepository Product => _productRepository ??= new ProductRepository(_context);
        public IProductPhotoRepository ProductPhoto => _productPhotoRepository ??= new ProductPhotoRepository(_context);
        public IStockRepository Stock => _stockRepository ??= new StockRepository(_context);
        public IUnitRepository Unit => _unitRepository ??= new UnitRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void  Dispose()
        {
            _context.Dispose();
        }
    }
}