using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
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
                .Property(p => p.Photo)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductPhotos)
                .HasForeignKey(p => p.ProductId);

            builder
                .ToTable("ProductPhotos");
        }
    }
}