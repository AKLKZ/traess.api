using Microsoft.EntityFrameworkCore;
using Traess.Domain.Entities;

namespace Traess.Data;

public class TraessDbContext : DbContext
{
    public TraessDbContext(DbContextOptions<TraessDbContext> options) : base(options)
    {
    }

    public DbSet<TractorUnit> TractorUnits => Set<TractorUnit>();

    public DbSet<Trailer> Trailers => Set<Trailer>();

    public DbSet<Driver> Drivers => Set<Driver>();

    public DbSet<TransportOrder> TransportOrders => Set<TransportOrder>();

    public DbSet<Trip> Trips => Set<Trip>();

    public DbSet<TripDriver> TripDrivers => Set<TripDriver>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TraessDbContext).Assembly);
    }
}
