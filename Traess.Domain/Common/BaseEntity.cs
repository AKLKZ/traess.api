namespace Traess.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? UpdatedAtUtc { get; set; }
}
