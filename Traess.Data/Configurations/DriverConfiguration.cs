using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traess.Domain.Entities;

namespace Traess.Data.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(d => d.LastName).IsRequired().HasMaxLength(100);

        builder.Property(d => d.NationalId).IsRequired().HasMaxLength(20);
        builder.HasIndex(d => d.NationalId).IsUnique();

        builder.Property(d => d.LicenseNumber).IsRequired().HasMaxLength(30);
        builder.HasIndex(d => d.LicenseNumber).IsUnique();

        builder.Property(d => d.LicenseCategories).IsRequired().HasMaxLength(50);
        builder.Property(d => d.PhoneNumber).IsRequired().HasMaxLength(30);
        builder.Property(d => d.Email).HasMaxLength(200);
    }
}
