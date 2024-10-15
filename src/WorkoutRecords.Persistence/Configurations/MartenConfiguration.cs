using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WorkoutRecords.Persistence.Configurations;

public static class MartenConfiguration
{
    public static void AddMarten(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MartenDB");

        services.AddMarten(options =>
        {
            options.Connection(connectionString);
            options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;

            // Add configurations for event sourcing and document storage
            options.Events.AddEventType(typeof(Workout));
            options.Events.AddEventType(typeof(RecordHistory));
            options.Schema.For<Workout>().Identity(x => x.Id);
            options.Schema.For<RecordHistory>().Identity(x => x.Id);
        });
    }
}
