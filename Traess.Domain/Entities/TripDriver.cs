namespace Traess.Domain.Entities;

// Join entity modeling team driving: multiple Drivers can rotate on a single Trip
// when the assigned TractorUnit has a sleeping cabin.
public class TripDriver
{
    public Guid TripId { get; set; }

    public Trip? Trip { get; set; }

    public Guid DriverId { get; set; }

    public Driver? Driver { get; set; }

    public bool IsLead { get; set; }

    public DateTime AssignedAt { get; set; }
}
