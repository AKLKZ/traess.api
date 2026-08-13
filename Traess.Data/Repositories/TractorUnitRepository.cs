using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Data.Repositories;

public class TractorUnitRepository : EfRepository<TractorUnit>, ITractorUnitRepository
{
    public TractorUnitRepository(TraessDbContext dbContext) : base(dbContext)
    {
    }
}
