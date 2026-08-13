using Microsoft.EntityFrameworkCore;
using Traess.Domain.Common;
using Traess.Domain.Repositories;

namespace Traess.Data.Repositories;

public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly TraessDbContext DbContext;
    protected readonly DbSet<TEntity> Entities;

    public EfRepository(TraessDbContext dbContext)
    {
        DbContext = dbContext;
        Entities = dbContext.Set<TEntity>();
    }

    public async Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await Entities.FindAsync([id], cancellationToken);

        return entity is null
            ? Result<TEntity>.Failure(NotFoundError(id))
            : Result<TEntity>.Success(entity);
    }

    public async Task<Result<IReadOnlyList<TEntity>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await Entities.AsNoTracking().ToListAsync(cancellationToken);

        return Result<IReadOnlyList<TEntity>>.Success(entities);
    }

    public async Task<Result<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedAtUtc = DateTime.UtcNow;

        await Entities.AddAsync(entity, cancellationToken);

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            return Result<TEntity>.Failure(SaveFailedError(ex));
        }

        return Result<TEntity>.Success(entity);
    }

    public async Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedAtUtc = DateTime.UtcNow;

        Entities.Update(entity);

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return Result<TEntity>.Failure(NotFoundError(entity.Id));
        }
        catch (DbUpdateException ex)
        {
            return Result<TEntity>.Failure(SaveFailedError(ex));
        }

        return Result<TEntity>.Success(entity);
    }

    public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await Entities.FindAsync([id], cancellationToken);

        if (entity is null)
            return Result.Failure(NotFoundError(id));

        Entities.Remove(entity);

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            return Result.Failure(SaveFailedError(ex));
        }

        return Result.Success();
    }

    private static Error NotFoundError(Guid id) => new(
        Title: $"{typeof(TEntity).Name} not found",
        Detail: $"No {typeof(TEntity).Name} was found with id '{id}'.",
        Status: 404);

    private static Error SaveFailedError(DbUpdateException ex) => new(
        Title: $"Could not save {typeof(TEntity).Name}",
        Detail: ex.InnerException?.Message ?? ex.Message,
        Status: 409);
}
