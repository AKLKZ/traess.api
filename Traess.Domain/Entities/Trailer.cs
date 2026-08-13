using Traess.Domain.Common;
using Traess.Domain.Enums;

namespace Traess.Domain.Entities;

public class Trailer : BaseEntity
{
    public string LicensePlate { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int Year { get; set; }

    public string ChassisNumber { get; set; } = string.Empty;

    public TrailerType TrailerType { get; set; }

    public int AxlesCount { get; set; }

    public decimal UnladenWeightKg { get; set; }

    public decimal MaxPayloadWeightKg { get; set; }

    // Gross weight when fully loaded, compared against TractorUnit.MaxTowableWeightKg to check compatibility.
    public decimal GrossWeightKg { get; set; }

    public CouplingType CouplingType { get; set; }

    public decimal? CapacityVolumeM3 { get; set; }

    public DateOnly ItvExpiryDate { get; set; }

    public DateOnly InsuranceExpiryDate { get; set; }

    public OwnershipType OwnershipType { get; set; }

    public FleetVehicleStatus Status { get; set; }

    public string? Notes { get; set; }

    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
