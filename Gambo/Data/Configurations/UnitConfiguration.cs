using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(u => u.Name)
                .HasMaxLength(55)
                .IsRequired();

            builder
                .ToTable("Units");
        }
    }
}