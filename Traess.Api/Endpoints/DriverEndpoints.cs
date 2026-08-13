using AutoMapper;
using Traess.Api.Common;
using Traess.Api.Contracts;
using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Api.Endpoints;

public static class DriverEndpoints
{
    public static IEndpointRouteBuilder MapDriverEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/drivers").WithTags("Drivers");

        group.MapGet("/", async (IDriverRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetAllAsync();
            return result
                .MapData(list => (IReadOnlyList<DriverResponse>)list.Select(e => mapper.Map<DriverResponse>(e)).ToList())
                .ToHttpResult(mapper);
        });

        group.MapGet("/{id:guid}", async (Guid id, IDriverRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetByIdAsync(id);
            return result.MapData(e => mapper.Map<DriverResponse>(e)).ToHttpResult(mapper);
        });

        group.MapPost("/", async (CreateDriverRequest request, IDriverRepository repository, IMapper mapper) =>
        {
            var entity = mapper.Map<Driver>(request);
            var result = await repository.AddAsync(entity);
            return result
                .MapData(e => mapper.Map<DriverResponse>(e))
                .ToCreatedHttpResult(mapper, dto => $"/api/drivers/{dto.Id}");
        });

        group.MapPut("/{id:guid}", async (Guid id, UpdateDriverRequest request, IDriverRepository repository, IMapper mapper) =>
        {
            var existing = await repository.GetByIdAsync(id);
            if (existing.IsFailure)
                return existing.ToHttpResult(mapper);

            mapper.Map(request, existing.Data);
            var result = await repository.UpdateAsync(existing.Data);
            return result.MapData(e => mapper.Map<DriverResponse>(e)).ToHttpResult(mapper);
        });

        group.MapDelete("/{id:guid}", async (Guid id, IDriverRepository repository, IMapper mapper) =>
        {
            var result = await repository.DeleteAsync(id);
            return result.ToHttpResult(mapper);
        });

        return app;
    }
}
