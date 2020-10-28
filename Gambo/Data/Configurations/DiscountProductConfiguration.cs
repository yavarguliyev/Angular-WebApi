using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class DiscountProductConfiguration : IEntityTypeConfiguration<DiscountProduct>
    {
        public void Configure(EntityTypeBuilder<DiscountProduct> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(d => d.Discount)
                .WithMany(d => d.DiscountProducts)
                .HasForeignKey(d => d.DiscountId);

            builder
                .HasOne(d => d.Product)
                .WithMany(d => d.DiscountProducts)
                .HasForeignKey(d => d.ProductId);

            builder
                .ToTable("DiscountProducts");
        }
    }
}