using Marten;
using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Persistence.Repositories;

public class RecordHistoryRepository : IRecordHistoryRepository
{
    private readonly IDocumentSession _session;
    private readonly EventStore _eventStore;

    public RecordHistoryRepository(IDocumentSession session, EventStore eventStore)
    {
        _session = session;
        _eventStore = eventStore;
    }

    public async Task SaveAsync(RecordHistory recordHistory, CancellationToken cancellationToken = default)
    {
        var events = recordHistory.GetUncommittedEvents();
        foreach (var @event in events)
        {
            await _eventStore.AppendEventAsync(recordHistory.Id.Value, @event, cancellationToken);
        }
        recordHistory.ClearUncommittedEvents();
    }

    public async Task<RecordHistory?> GetByIdAsync(RecordHistoryId id, CancellationToken cancellationToken = default)
    {
        var events = await _eventStore.LoadEventsAsync(id.Value, cancellationToken);
        if (events.Count == 0)
        {
            return null;
        }

        var recordHistory = new RecordHistory(id);
        foreach (var @event in events)
        {
            recordHistory.ApplyEvent(@event);
        }

        return recordHistory;
    }
}
