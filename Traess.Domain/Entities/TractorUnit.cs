using Traess.Domain.Common;
using Traess.Domain.Enums;

namespace Traess.Domain.Entities;

public class TractorUnit : BaseEntity
{
    public string LicensePlate { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int Year { get; set; }

    public string ChassisNumber { get; set; } = string.Empty;

    public int EnginePowerHp { get; set; }

    public FuelType FuelType { get; set; }

    public decimal GrossVehicleWeightKg { get; set; }

    // Maximum weight the tractor unit is rated to tow, compared against Trailer.GrossWeightKg to check compatibility.
    public decimal MaxTowableWeightKg { get; set; }

    public CouplingType CouplingType { get; set; }

    public bool HasSleepingCabin { get; set; }

    // Number of berths; >1 enables assigning multiple Drivers to a Trip to rotate while driving.
    public int SleepingBerths { get; set; }

    public decimal CurrentOdometerKm { get; set; }

    public DateOnly ItvExpiryDate { get; set; }

    public DateOnly InsuranceExpiryDate { get; set; }

    public OwnershipType OwnershipType { get; set; }

    public DateOnly AcquisitionDate { get; set; }

    public FleetVehicleStatus Status { get; set; }

    public string? Notes { get; set; }

    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
