using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(c => c.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(c => c.Name)
                .HasMaxLength(55)
                .IsRequired();

            builder
                .Property(c => c.OrderBy)
                .IsRequired();

            builder
                .Property(c => c.Photo)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .ToTable("Categories");
        }
    }
}