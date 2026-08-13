using AutoMapper;
using Traess.Api.Common;
using Traess.Api.Contracts;
using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Api.Endpoints;

public static class TractorUnitEndpoints
{
    public static IEndpointRouteBuilder MapTractorUnitEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tractor-units").WithTags("TractorUnits");

        group.MapGet("/", async (ITractorUnitRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetAllAsync();
            return result
                .MapData(list => (IReadOnlyList<TractorUnitResponse>)list.Select(e => mapper.Map<TractorUnitResponse>(e)).ToList())
                .ToHttpResult(mapper);
        });

        group.MapGet("/{id:guid}", async (Guid id, ITractorUnitRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetByIdAsync(id);
            return result.MapData(e => mapper.Map<TractorUnitResponse>(e)).ToHttpResult(mapper);
        });

        group.MapPost("/", async (CreateTractorUnitRequest request, ITractorUnitRepository repository, IMapper mapper) =>
        {
            var entity = mapper.Map<TractorUnit>(request);
            var result = await repository.AddAsync(entity);
            return result
                .MapData(e => mapper.Map<TractorUnitResponse>(e))
                .ToCreatedHttpResult(mapper, dto => $"/api/tractor-units/{dto.Id}");
        });

        group.MapPut("/{id:guid}", async (Guid id, UpdateTractorUnitRequest request, ITractorUnitRepository repository, IMapper mapper) =>
        {
            var existing = await repository.GetByIdAsync(id);
            if (existing.IsFailure)
                return existing.ToHttpResult(mapper);

            mapper.Map(request, existing.Data);
            var result = await repository.UpdateAsync(existing.Data);
            return result.MapData(e => mapper.Map<TractorUnitResponse>(e)).ToHttpResult(mapper);
        });

        group.MapDelete("/{id:guid}", async (Guid id, ITractorUnitRepository repository, IMapper mapper) =>
        {
            var result = await repository.DeleteAsync(id);
            return result.ToHttpResult(mapper);
        });

        return app;
    }
}
