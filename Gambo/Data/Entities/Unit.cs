using System.Collections.Generic;

namespace Data.Entities
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}