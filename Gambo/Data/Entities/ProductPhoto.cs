namespace Data.Entities
{
    public class ProductPhoto : BaseEntity
    {
        public long ProductId { get; set; }
        public string Photo { get; set; }

        public Product Product { get; set; }
    }
}