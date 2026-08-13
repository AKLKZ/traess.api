using Traess.Domain.Common;
using Traess.Domain.Enums;

namespace Traess.Domain.Entities;

public class TransportOrder : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;

    public string ClientName { get; set; } = string.Empty;

    public DateOnly RequestedDate { get; set; }

    public TransportOrderStatus Status { get; set; }

    public string? Priority { get; set; }

    public string? Notes { get; set; }

    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
