using EventStore.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WorkoutRecords.Infrastructure.Configurations;

public static class EventStoreConfiguration
{
    public static IServiceCollection AddEventStore(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = EventStoreClientSettings.Create(configuration.GetConnectionString("EventStore"));
        var eventStoreClient = new EventStoreClient(settings);

        services.AddSingleton(eventStoreClient);

        return services;
    }
}
