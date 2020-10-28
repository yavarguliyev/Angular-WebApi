using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(s => s.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .HasOne(s => s.Product)
                .WithMany(s => s.Stocks)
                .HasForeignKey(s => s.ProductId);

            builder
                .HasOne(s => s.Branch)
                .WithMany(s => s.Stocks)
                .HasForeignKey(s => s.BranchId);

            builder
                .ToTable("Stocks");
        }
    }
}