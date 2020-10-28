namespace Data.Entities
{
    public class DiscountProduct
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long DiscountId { get; set; }

        public Product Product { get; set; }
        public Discount Discount { get; set; }
    }
}