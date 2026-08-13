using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traess.Domain.Entities;

namespace Traess.Data.Configurations;

public class TripDriverConfiguration : IEntityTypeConfiguration<TripDriver>
{
    public void Configure(EntityTypeBuilder<TripDriver> builder)
    {
        builder.HasKey(td => new { td.TripId, td.DriverId });

        builder.HasOne(td => td.Trip)
            .WithMany(t => t.TripDrivers)
            .HasForeignKey(td => td.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(td => td.Driver)
            .WithMany(d => d.TripDrivers)
            .HasForeignKey(td => td.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
