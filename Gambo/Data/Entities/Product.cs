using System.Collections.Generic;

namespace Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public long UnitId { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }

        public Unit Unit { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
        public ICollection<DiscountProduct> DiscountProducts { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}