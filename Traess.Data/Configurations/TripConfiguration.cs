using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traess.Domain.Entities;

namespace Traess.Data.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.OriginAddress).IsRequired().HasMaxLength(300);
        builder.Property(t => t.DestinationAddress).IsRequired().HasMaxLength(300);
        builder.Property(t => t.CargoDescription).HasMaxLength(500);

        builder.Property(t => t.DistanceKm).HasPrecision(10, 2);
        builder.Property(t => t.CargoWeightKg).HasPrecision(10, 2);

        builder.HasOne(t => t.TractorUnit)
            .WithMany(u => u.Trips)
            .HasForeignKey(t => t.TractorUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Trailer)
            .WithMany(tr => tr.Trips)
            .HasForeignKey(t => t.TrailerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
