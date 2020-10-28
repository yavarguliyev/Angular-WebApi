using System.Collections.Generic;

namespace Data.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}