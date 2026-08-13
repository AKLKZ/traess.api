using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traess.Domain.Entities;

namespace Traess.Data.Configurations;

public class TractorUnitConfiguration : IEntityTypeConfiguration<TractorUnit>
{
    public void Configure(EntityTypeBuilder<TractorUnit> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.LicensePlate).IsRequired().HasMaxLength(20);
        builder.HasIndex(t => t.LicensePlate).IsUnique();

        builder.Property(t => t.Brand).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Model).IsRequired().HasMaxLength(100);
        builder.Property(t => t.ChassisNumber).IsRequired().HasMaxLength(50);

        builder.Property(t => t.GrossVehicleWeightKg).HasPrecision(10, 2);
        builder.Property(t => t.MaxTowableWeightKg).HasPrecision(10, 2);
        builder.Property(t => t.CurrentOdometerKm).HasPrecision(12, 2);
    }
}
