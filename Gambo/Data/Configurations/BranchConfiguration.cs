using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(b => b.Name)
                .HasMaxLength(55)
                .IsRequired();

            builder
                .Property(b => b.Address)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .Property(b => b.Longitude)
                .IsRequired();

            builder
               .Property(b => b.Latitude)
               .IsRequired();

            builder
                .ToTable("Branches");
        }
    }
}