using Traess.Domain.Common;
using Traess.Domain.Enums;

namespace Traess.Domain.Entities;

public class Trip : BaseEntity
{
    public Guid TransportOrderId { get; set; }

    public TransportOrder? TransportOrder { get; set; }

    public Guid TractorUnitId { get; set; }

    public TractorUnit? TractorUnit { get; set; }

    public Guid TrailerId { get; set; }

    public Trailer? Trailer { get; set; }

    public string OriginAddress { get; set; } = string.Empty;

    public string DestinationAddress { get; set; } = string.Empty;

    public DateTime ScheduledDepartureAt { get; set; }

    public DateTime? ScheduledArrivalAt { get; set; }

    public DateTime? ActualDepartureAt { get; set; }

    public DateTime? ActualArrivalAt { get; set; }

    public decimal? DistanceKm { get; set; }

    public string? CargoDescription { get; set; }

    // Compared against the assigned Trailer/TractorUnit capacity to check feasibility.
    public decimal? CargoWeightKg { get; set; }

    public TripStatus Status { get; set; }

    public string? Notes { get; set; }

    public ICollection<TripDriver> TripDrivers { get; set; } = new List<TripDriver>();
}
