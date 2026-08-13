using AutoMapper;
using Traess.Api.Common;
using Traess.Api.Contracts;
using Traess.Domain.Entities;
using Traess.Domain.Repositories;

namespace Traess.Api.Endpoints;

public static class TransportOrderEndpoints
{
    public static IEndpointRouteBuilder MapTransportOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/transport-orders").WithTags("TransportOrders");

        group.MapGet("/", async (ITransportOrderRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetAllAsync();
            return result
                .MapData(list => (IReadOnlyList<TransportOrderResponse>)list.Select(e => mapper.Map<TransportOrderResponse>(e)).ToList())
                .ToHttpResult(mapper);
        });

        group.MapGet("/{id:guid}", async (Guid id, ITransportOrderRepository repository, IMapper mapper) =>
        {
            var result = await repository.GetByIdAsync(id);
            return result.MapData(e => mapper.Map<TransportOrderResponse>(e)).ToHttpResult(mapper);
        });

        group.MapPost("/", async (CreateTransportOrderRequest request, ITransportOrderRepository repository, IMapper mapper) =>
        {
            var entity = mapper.Map<TransportOrder>(request);
            var result = await repository.AddAsync(entity);
            return result
                .MapData(e => mapper.Map<TransportOrderResponse>(e))
                .ToCreatedHttpResult(mapper, dto => $"/api/transport-orders/{dto.Id}");
        });

        group.MapPut("/{id:guid}", async (Guid id, UpdateTransportOrderRequest request, ITransportOrderRepository repository, IMapper mapper) =>
        {
            var existing = await repository.GetByIdAsync(id);
            if (existing.IsFailure)
                return existing.ToHttpResult(mapper);

            mapper.Map(request, existing.Data);
            var result = await repository.UpdateAsync(existing.Data);
            return result.MapData(e => mapper.Map<TransportOrderResponse>(e)).ToHttpResult(mapper);
        });

        group.MapDelete("/{id:guid}", async (Guid id, ITransportOrderRepository repository, IMapper mapper) =>
        {
            var result = await repository.DeleteAsync(id);
            return result.ToHttpResult(mapper);
        });

        return app;
    }
}
