using Traess.Domain.Enums;

namespace Traess.Api.Contracts;

public record DriverResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string NationalId,
    string LicenseNumber,
    string LicenseCategories,
    DateOnly LicenseExpiryDate,
    DateOnly? CapCertificateExpiryDate,
    string PhoneNumber,
    string? Email,
    DateOnly HireDate,
    DriverStatus Status,
    string? Notes,
    DateTime CreatedAtUtc,
    DateTime? UpdatedAtUtc);

public record CreateDriverRequest(
    string FirstName,
    string LastName,
    string NationalId,
    string LicenseNumber,
    string LicenseCategories,
    DateOnly LicenseExpiryDate,
    DateOnly? CapCertificateExpiryDate,
    string PhoneNumber,
    string? Email,
    DateOnly HireDate,
    DriverStatus Status,
    string? Notes);

public record UpdateDriverRequest(
    string FirstName,
    string LastName,
    string NationalId,
    string LicenseNumber,
    string LicenseCategories,
    DateOnly LicenseExpiryDate,
    DateOnly? CapCertificateExpiryDate,
    string PhoneNumber,
    string? Email,
    DateOnly HireDate,
    DriverStatus Status,
    string? Notes);
