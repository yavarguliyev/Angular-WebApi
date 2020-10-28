namespace Data.Entities
{
    public class Stock : BaseEntity
    {
        public long BranchId { get; set; }
        public long ProductId { get; set; }
        public double Quanity { get; set; }
        public decimal Price { get; set; }

        public Branch Branch { get; set; }
        public Product Product { get; set; }
    }
}