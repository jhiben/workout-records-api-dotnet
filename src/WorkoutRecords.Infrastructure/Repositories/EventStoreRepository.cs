using EventStore.Client;
using System.Text.Json;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Infrastructure.Repositories;

public class EventStoreRepository<T> where T : IAggregateRoot
{
    private readonly EventStoreClient _eventStoreClient;

    public EventStoreRepository(EventStoreClient eventStoreClient)
    {
        _eventStoreClient = eventStoreClient;
    }

    public async Task SaveAsync(T aggregate, CancellationToken cancellationToken = default)
    {
        var events = aggregate.GetUncommittedEvents();
        var streamName = GetStreamName(aggregate);

        var eventData = events.Select(@event =>
            new EventData(
                Uuid.NewUuid(),
                @event.GetType().Name,
                JsonSerializer.SerializeToUtf8Bytes(@event),
                contentType: "application/json"
            )).ToArray();

        await _eventStoreClient.AppendToStreamAsync(streamName, StreamState.Any, eventData, cancellationToken: cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var streamName = GetStreamName(id);
        var result = _eventStoreClient.ReadStreamAsync(Direction.Forwards, streamName, StreamPosition.Start, cancellationToken: cancellationToken);

        if (await result.ReadState == ReadState.StreamNotFound)
        {
            throw new InvalidOperationException($"Stream not found for id {id}");
        }

        var aggregate = Activator.CreateInstance<T>();

        await foreach (var @event in result)
        {
            var eventData = JsonSerializer.Deserialize(@event.Event.Data.Span, Type.GetType(@event.Event.EventType));
            aggregate.ApplyEvent(eventData);
        }

        return aggregate;
    }

    private string GetStreamName(T aggregate) => $"{typeof(T).Name}-{aggregate.Id}";

    private string GetStreamName(Guid id) => $"{typeof(T).Name}-{id}";
}
