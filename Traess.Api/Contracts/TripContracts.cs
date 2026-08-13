using Traess.Domain.Enums;

namespace Traess.Api.Contracts;

public record TripResponse(
    Guid Id,
    Guid TransportOrderId,
    Guid TractorUnitId,
    Guid TrailerId,
    string OriginAddress,
    string DestinationAddress,
    DateTime ScheduledDepartureAt,
    DateTime? ScheduledArrivalAt,
    DateTime? ActualDepartureAt,
    DateTime? ActualArrivalAt,
    decimal? DistanceKm,
    string? CargoDescription,
    decimal? CargoWeightKg,
    TripStatus Status,
    string? Notes,
    DateTime CreatedAtUtc,
    DateTime? UpdatedAtUtc);

public record CreateTripRequest(
    Guid TransportOrderId,
    Guid TractorUnitId,
    Guid TrailerId,
    string OriginAddress,
    string DestinationAddress,
    DateTime ScheduledDepartureAt,
    DateTime? ScheduledArrivalAt,
    decimal? DistanceKm,
    string? CargoDescription,
    decimal? CargoWeightKg,
    TripStatus Status,
    string? Notes);

public record UpdateTripRequest(
    Guid TransportOrderId,
    Guid TractorUnitId,
    Guid TrailerId,
    string OriginAddress,
    string DestinationAddress,
    DateTime ScheduledDepartureAt,
    DateTime? ScheduledArrivalAt,
    DateTime? ActualDepartureAt,
    DateTime? ActualArrivalAt,
    decimal? DistanceKm,
    string? CargoDescription,
    decimal? CargoWeightKg,
    TripStatus Status,
    string? Notes);
