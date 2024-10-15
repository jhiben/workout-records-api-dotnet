using Marten;
using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Persistence.Repositories;

public class RecordHistoryRepository : IRecordHistoryRepository
{
    private readonly IDocumentSession _session;

    public RecordHistoryRepository(IDocumentSession session)
    {
        _session = session;
    }

    public async Task SaveAsync(RecordHistory recordHistory, CancellationToken cancellationToken = default)
    {
        _session.Store(recordHistory);
        await _session.SaveChangesAsync(cancellationToken);
    }

    public async Task<RecordHistory?> GetByIdAsync(RecordHistoryId id, CancellationToken cancellationToken = default)
    {
        return await _session.LoadAsync<RecordHistory>(id, cancellationToken);
    }
}
