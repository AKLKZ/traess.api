using Traess.Domain.Enums;

namespace Traess.Api.Contracts;

public record TransportOrderResponse(
    Guid Id,
    string OrderNumber,
    string ClientName,
    DateOnly RequestedDate,
    TransportOrderStatus Status,
    string? Priority,
    string? Notes,
    DateTime CreatedAtUtc,
    DateTime? UpdatedAtUtc);

public record CreateTransportOrderRequest(
    string OrderNumber,
    string ClientName,
    DateOnly RequestedDate,
    TransportOrderStatus Status,
    string? Priority,
    string? Notes);

public record UpdateTransportOrderRequest(
    string OrderNumber,
    string ClientName,
    DateOnly RequestedDate,
    TransportOrderStatus Status,
    string? Priority,
    string? Notes);
