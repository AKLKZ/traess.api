using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Data.Repositories;

public class TripRepository : EfRepository<Trip>, ITripRepository
{
    public TripRepository(TraessDbContext dbContext) : base(dbContext)
    {
    }
}
