using Traess.Domain.Common;

namespace Traess.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Result<IReadOnlyList<TEntity>>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Result<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
