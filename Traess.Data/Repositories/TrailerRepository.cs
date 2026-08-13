using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Data.Repositories;

public class TrailerRepository : EfRepository<Trailer>, ITrailerRepository
{
    public TrailerRepository(TraessDbContext dbContext) : base(dbContext)
    {
    }
}
