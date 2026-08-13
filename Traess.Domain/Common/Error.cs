namespace Traess.Domain.Common;

public sealed record Error(
    string Title,
    string Detail,
    int Status,
    string? Type = null,
    string? Instance = null,
    IDictionary<string, object?>? Extensions = null);
