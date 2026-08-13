using AutoMapper;
using Traess.Api.Common;
using Traess.Api.Contracts;
using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Api.Endpoints;

public static class TripEndpoints
{
    public static IEndpointRouteBuilder MapTripEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/trips").WithTags("Trips");

        group.MapGet("/", async (ITripRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetAllAsync();
            return result
                .MapData(list => (IReadOnlyList<TripResponse>)list.Select(e => mapper.Map<TripResponse>(e)).ToList())
                .ToHttpResult(mapper);
        });

        group.MapGet("/{id:guid}", async (Guid id, ITripRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetByIdAsync(id);
            return result.MapData(e => mapper.Map<TripResponse>(e)).ToHttpResult(mapper);
        });

        group.MapPost("/", async (CreateTripRequest request, ITripRepository repository, IMapper mapper) =>
        {
            var entity = mapper.Map<Trip>(request);
            var result = await repository.AddAsync(entity);
            return result
                .MapData(e => mapper.Map<TripResponse>(e))
                .ToCreatedHttpResult(mapper, dto => $"/api/trips/{dto.Id}");
        });

        group.MapPut("/{id:guid}", async (Guid id, UpdateTripRequest request, ITripRepository repository, IMapper mapper) =>
        {
            var existing = await repository.GetByIdAsync(id);
            if (existing.IsFailure)
                return existing.ToHttpResult(mapper);

            mapper.Map(request, existing.Data);
            var result = await repository.UpdateAsync(existing.Data);
            return result.MapData(e => mapper.Map<TripResponse>(e)).ToHttpResult(mapper);
        });

        group.MapDelete("/{id:guid}", async (Guid id, ITripRepository repository, IMapper mapper) =>
        {
            var result = await repository.DeleteAsync(id);
            return result.ToHttpResult(mapper);
        });

        return app;
    }
}
