using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Persistence.Repositories;

namespace WorkoutRecords.Application.Services;

public class RecordHistoryService
{
    private readonly RecordHistoryRepository _recordHistoryRepository;

    public RecordHistoryService(RecordHistoryRepository recordHistoryRepository)
    {
        _recordHistoryRepository = recordHistoryRepository;
    }

    public async Task SaveRecordHistoryAsync(RecordHistory recordHistory, CancellationToken cancellationToken = default)
    {
        await _recordHistoryRepository.SaveAsync(recordHistory, cancellationToken);
    }

    public async Task<RecordHistory?> GetRecordHistoryByIdAsync(RecordHistoryId id, CancellationToken cancellationToken = default)
    {
        return await _recordHistoryRepository.GetByIdAsync(id, cancellationToken);
    }
}
