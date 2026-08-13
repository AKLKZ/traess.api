using Traess.Domain.Common;
using Traess.Domain.Enums;

namespace Traess.Domain.Entities;

public class Driver : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string NationalId { get; set; } = string.Empty;

    public string LicenseNumber { get; set; } = string.Empty;

    // e.g. "C+E"
    public string LicenseCategories { get; set; } = string.Empty;

    public DateOnly LicenseExpiryDate { get; set; }

    public DateOnly? CapCertificateExpiryDate { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public string? Email { get; set; }

    public DateOnly HireDate { get; set; }

    public DriverStatus Status { get; set; }

    public string? Notes { get; set; }

    public ICollection<TripDriver> TripDrivers { get; set; } = new List<TripDriver>();
}
