using Data.Entities;

namespace Api.Resources
{
    public class ProductResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string[] Photos { get; set; }

        public DiscountResource DiscountResource { get; set; }
    }
}