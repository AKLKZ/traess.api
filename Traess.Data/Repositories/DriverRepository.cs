using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Data.Repositories;

public class DriverRepository : EfRepository<Driver>, IDriverRepository
{
    public DriverRepository(TraessDbContext dbContext) : base(dbContext)
    {
    }
}
