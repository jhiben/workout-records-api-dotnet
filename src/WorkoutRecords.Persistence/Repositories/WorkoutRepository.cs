using Marten;
using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Persistence.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly IDocumentSession _session;

    public WorkoutRepository(IDocumentSession session)
    {
        _session = session;
    }

    public async Task SaveAsync(Workout workout, CancellationToken cancellationToken = default)
    {
        _session.Store(workout);
        await _session.SaveChangesAsync(cancellationToken);
    }

    public async Task<Workout?> GetByIdAsync(WorkoutId id, CancellationToken cancellationToken = default)
    {
        return await _session.LoadAsync<Workout>(id, cancellationToken);
    }
}
