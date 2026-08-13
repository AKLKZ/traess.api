using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traess.Domain.Entities;

namespace Traess.Data.Configurations;

public class TrailerConfiguration : IEntityTypeConfiguration<Trailer>
{
    public void Configure(EntityTypeBuilder<Trailer> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.LicensePlate).IsRequired().HasMaxLength(20);
        builder.HasIndex(t => t.LicensePlate).IsUnique();

        builder.Property(t => t.Brand).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Model).IsRequired().HasMaxLength(100);
        builder.Property(t => t.ChassisNumber).IsRequired().HasMaxLength(50);

        builder.Property(t => t.UnladenWeightKg).HasPrecision(10, 2);
        builder.Property(t => t.MaxPayloadWeightKg).HasPrecision(10, 2);
        builder.Property(t => t.GrossWeightKg).HasPrecision(10, 2);
        builder.Property(t => t.CapacityVolumeM3).HasPrecision(10, 2);
    }
}
