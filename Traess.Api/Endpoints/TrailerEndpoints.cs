using AutoMapper;
using Traess.Api.Common;
using Traess.Api.Contracts;
using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Api.Endpoints;

public static class TrailerEndpoints
{
    public static IEndpointRouteBuilder MapTrailerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/trailers").WithTags("Trailers");

        group.MapGet("/", async (ITrailerRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetAllAsync();
            return result
                .MapData(list => (IReadOnlyList<TrailerResponse>)list.Select(e => mapper.Map<TrailerResponse>(e)).ToList())
                .ToHttpResult(mapper);
        });

        group.MapGet("/{id:guid}", async (Guid id, ITrailerRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetByIdAsync(id);
            return result.MapData(e => mapper.Map<TrailerResponse>(e)).ToHttpResult(mapper);
        });

        group.MapPost("/", async (CreateTrailerRequest request, ITrailerRepository repository, IMapper mapper) =>
        {
            var entity = mapper.Map<Trailer>(request);
            var result = await repository.AddAsync(entity);
            return result
                .MapData(e => mapper.Map<TrailerResponse>(e))
                .ToCreatedHttpResult(mapper, dto => $"/api/trailers/{dto.Id}");
        });

        group.MapPut("/{id:guid}", async (Guid id, UpdateTrailerRequest request, ITrailerRepository repository, IMapper mapper) =>
        {
            var existing = await repository.GetByIdAsync(id);
            if (existing.IsFailure)
                return existing.ToHttpResult(mapper);

            mapper.Map(request, existing.Data);
            var result = await repository.UpdateAsync(existing.Data);
            return result.MapData(e => mapper.Map<TrailerResponse>(e)).ToHttpResult(mapper);
        });

        group.MapDelete("/{id:guid}", async (Guid id, ITrailerRepository repository, IMapper mapper) =>
        {
            var result = await repository.DeleteAsync(id);
            return result.ToHttpResult(mapper);
        });

        return app;
    }
}
