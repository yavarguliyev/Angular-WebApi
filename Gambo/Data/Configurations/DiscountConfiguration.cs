using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(d => d.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(d => d.Name)
                .HasMaxLength(55)
                .IsRequired();

            builder
                .Property(d => d.StartDate)
                .IsRequired();

            builder
                .Property(d => d.EndDate)
                .IsRequired();

            builder
                .Property(d => d.Percentage)
                .IsRequired();

            builder
                .ToTable("Discounts");
        }
    }
}