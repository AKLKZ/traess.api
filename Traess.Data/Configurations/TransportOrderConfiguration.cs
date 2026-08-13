using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traess.Domain.Entities;

namespace Traess.Data.Configurations;

public class TransportOrderConfiguration : IEntityTypeConfiguration<TransportOrder>
{
    public void Configure(EntityTypeBuilder<TransportOrder> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderNumber).IsRequired().HasMaxLength(50);
        builder.HasIndex(o => o.OrderNumber).IsUnique();

        builder.Property(o => o.ClientName).IsRequired().HasMaxLength(200);
        builder.Property(o => o.Priority).HasMaxLength(30);

        builder.HasMany(o => o.Trips)
            .WithOne(t => t.TransportOrder)
            .HasForeignKey(t => t.TransportOrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
