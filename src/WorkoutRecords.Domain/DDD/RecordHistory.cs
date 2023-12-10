using WorkoutRecords.Domain.DDD.Exceptions;

namespace WorkoutRecords.Domain.DDD;

public abstract class RecordHistory<T>
    where T : Record
{
    private readonly List<T> _records = [];

    protected RecordHistory(WorkoutId workoutId) => WorkoutId = workoutId;

    public WorkoutId WorkoutId { get; }

    public IReadOnlyList<T> Records => _records;

    public void SetNew(T record)
    {
        var existing = _records.LastOrDefault(r => r.Date <= record.Date);
        if (existing is not null)
        {
            if (!record.IsAfter(existing))
            {
                throw new InvalidRecordException("New record must be set after the last one.");
            }

            if (!record.IsBetterThan(existing))
            {
                throw new InvalidRecordException("New record must be better than the last one.");
            }
        }

        _records.Add(record);
    }
}

public class RepsRecordHistory(WorkoutId workoutId) : RecordHistory<RepsRecord>(workoutId) { }

public class TimeRecordHistory(WorkoutId workoutId) : RecordHistory<TimeRecord>(workoutId) { }

public class WeightRecordHistory(WorkoutId workoutId) : RecordHistory<WeightRecord>(workoutId) { }
