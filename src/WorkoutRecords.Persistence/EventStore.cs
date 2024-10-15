using Marten;
using Marten.Events;
using WorkoutRecords.Domain.DDD;

namespace WorkoutRecords.Persistence;

public class EventStore
{
    private readonly IDocumentStore _store;

    public EventStore(IDocumentStore store)
    {
        _store = store;
    }

    public async Task AppendEventAsync<T>(Guid streamId, T @event, CancellationToken cancellationToken = default)
    {
        using var session = _store.LightweightSession();
        session.Events.Append(streamId, @event);
        await session.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<IEvent>> LoadEventsAsync(Guid streamId, CancellationToken cancellationToken = default)
    {
        using var session = _store.LightweightSession();
        var events = await session.Events.FetchStreamAsync(streamId, token: cancellationToken);
        return events;
    }
}
