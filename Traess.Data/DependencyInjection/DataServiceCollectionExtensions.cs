using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Traess.Data.Repositories;
using Traess.Domain.Repositories;

namespace Traess.Data.DependencyInjection;

public static class DataServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TraessDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITractorUnitRepository, TractorUnitRepository>();
        services.AddScoped<ITrailerRepository, TrailerRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<ITransportOrderRepository, TransportOrderRepository>();
        services.AddScoped<ITripRepository, TripRepository>();

        return services;
    }
}
