namespace WorkoutRecords.Domain.DDD;

public abstract class RecordHistory<T>
    where T : Record
{
    private readonly List<T> _records = [];

    protected RecordHistory(WorkoutId workoutId) => WorkoutId = workoutId;

    public WorkoutId WorkoutId { get; }

    public IReadOnlyList<T> Records => _records;

    public void Add(T record) => _records.Add(record);
}

public class RepsRecordHistory(WorkoutId workoutId) : RecordHistory<RepsRecord>(workoutId) { }

public class TimeRecordHistory(WorkoutId workoutId) : RecordHistory<TimeRecord>(workoutId) { }

public class WeightRecordHistory(WorkoutId workoutId) : RecordHistory<WeightRecord>(workoutId) { }
