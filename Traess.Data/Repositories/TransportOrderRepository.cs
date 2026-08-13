using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Data.Repositories;

public class TransportOrderRepository : EfRepository<TransportOrder>, ITransportOrderRepository
{
    public TransportOrderRepository(TraessDbContext dbContext) : base(dbContext)
    {
    }
}
