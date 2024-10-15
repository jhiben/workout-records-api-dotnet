using Marten;
using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Persistence.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly IDocumentSession _session;
    private readonly EventStore _eventStore;

    public WorkoutRepository(IDocumentSession session, EventStore eventStore)
    {
        _session = session;
        _eventStore = eventStore;
    }

    public async Task SaveAsync(Workout workout, CancellationToken cancellationToken = default)
    {
        var events = workout.GetUncommittedEvents();
        foreach (var @event in events)
        {
            await _eventStore.AppendEventAsync(workout.Id.Value, @event, cancellationToken);
        }
        workout.ClearUncommittedEvents();
    }

    public async Task<Workout?> GetByIdAsync(WorkoutId id, CancellationToken cancellationToken = default)
    {
        var events = await _eventStore.LoadEventsAsync(id.Value, cancellationToken);
        if (events.Count == 0)
        {
            return null;
        }

        var workout = new Workout(id);
        foreach (var @event in events)
        {
            workout.ApplyEvent(@event);
        }

        return workout;
    }
}
