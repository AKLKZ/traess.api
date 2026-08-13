using Traess.Domain.Enums;

namespace Traess.Api.Contracts;

public record TrailerResponse(
    Guid Id,
    string LicensePlate,
    string Brand,
    string Model,
    int Year,
    string ChassisNumber,
    TrailerType TrailerType,
    int AxlesCount,
    decimal UnladenWeightKg,
    decimal MaxPayloadWeightKg,
    decimal GrossWeightKg,
    CouplingType CouplingType,
    decimal? CapacityVolumeM3,
    DateOnly ItvExpiryDate,
    DateOnly InsuranceExpiryDate,
    OwnershipType OwnershipType,
    FleetVehicleStatus Status,
    string? Notes,
    DateTime CreatedAtUtc,
    DateTime? UpdatedAtUtc);

public record CreateTrailerRequest(
    string LicensePlate,
    string Brand,
    string Model,
    int Year,
    string ChassisNumber,
    TrailerType TrailerType,
    int AxlesCount,
    decimal UnladenWeightKg,
    decimal MaxPayloadWeightKg,
    decimal GrossWeightKg,
    CouplingType CouplingType,
    decimal? CapacityVolumeM3,
    DateOnly ItvExpiryDate,
    DateOnly InsuranceExpiryDate,
    OwnershipType OwnershipType,
    FleetVehicleStatus Status,
    string? Notes);

public record UpdateTrailerRequest(
    string LicensePlate,
    string Brand,
    string Model,
    int Year,
    string ChassisNumber,
    TrailerType TrailerType,
    int AxlesCount,
    decimal UnladenWeightKg,
    decimal MaxPayloadWeightKg,
    decimal GrossWeightKg,
    CouplingType CouplingType,
    decimal? CapacityVolumeM3,
    DateOnly ItvExpiryDate,
    DateOnly InsuranceExpiryDate,
    OwnershipType OwnershipType,
    FleetVehicleStatus Status,
    string? Notes);
