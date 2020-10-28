using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(p => p.Name)
                .HasMaxLength(155)
                .IsRequired();

            builder
                .HasOne(p => p.Unit)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.UnitId);

            builder
               .HasOne(p => p.Category)
               .WithMany(p => p.Products)
               .HasForeignKey(p => p.CategoryId);

            builder
                .Property(p => p.IsFeatured)
                .IsRequired()
                .HasDefaultValue(false);

            builder
               .Property(p => p.IsNew)
               .IsRequired()
               .HasDefaultValue(false);

            builder
                .Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder
               .Property(p => p.Details)
               .HasColumnType("ntext");

            builder
                .ToTable("Products");
        }
    }
}