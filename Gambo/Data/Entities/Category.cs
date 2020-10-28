using System.Collections.Generic;

namespace Data.Entities
{
    public class Category : BaseEntity
    {
        public int OrderBy { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}