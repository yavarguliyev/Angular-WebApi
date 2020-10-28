using Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWork
    {
        IBranchRepository Branch { get; }
        ICategoryRepository Category { get; }
        IDiscountRepository Discount { get; }
        IDiscountProductRepository DiscountProduct { get; }
        IProductRepository Product { get; }
        IProductPhotoRepository ProductPhoto { get; }
        IStockRepository Stock { get; }
        IUnitRepository Unit { get; }

        Task<int> CommitAsync();
    }
}