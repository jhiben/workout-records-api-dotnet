using StronglyTypedIds;
using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public abstract class RecordHistory : Entity<RecordHistoryId>, IAggregateRoot
{
    protected RecordHistory(RecordHistoryId id)
        : base(id) { }

    public static RepsRecordHistory ForReps(WorkoutId workoutId) => new(workoutId);

    public static TimeRecordHistory ForTime(WorkoutId workoutId) => new(workoutId);

    public static WeightRecordHistory ForWeight(WorkoutId workoutId) => new(workoutId);
}

public abstract class RecordHistory<T> : RecordHistory
    where T : Record
{
    private readonly List<T> _records = [];

    protected RecordHistory(WorkoutId workoutId)
        : this(RecordHistoryId.New(), workoutId) { }

    private RecordHistory(RecordHistoryId id, WorkoutId workoutId)
        : base(id)
    {
        WorkoutId = workoutId;
    }

    public WorkoutId WorkoutId { get; }

    public IReadOnlyList<T> Records => _records;

    public void SetNew(T record)
    {
        var last = _records.LastOrDefault();
        if (last is not null)
        {
            if (!record.IsAfter(last))
            {
                throw new InvalidRecordException("New record must be set after the last one.");
            }

            if (!record.IsBetterThan(last))
            {
                throw new InvalidRecordException("New record must be better than the last one.");
            }
        }

        _records.Add(record);
    }
}

public class RepsRecordHistory : RecordHistory<RepsRecord>
{
    internal RepsRecordHistory(WorkoutId workoutId)
        : base(workoutId) { }
}

public class TimeRecordHistory : RecordHistory<TimeRecord>
{
    internal TimeRecordHistory(WorkoutId workoutId)
        : base(workoutId) { }
}

public class WeightRecordHistory : RecordHistory<WeightRecord>
{
    internal WeightRecordHistory(WorkoutId workoutId)
        : base(workoutId) { }
}

[StronglyTypedId(converters: StronglyTypedIdConverter.None)]
public partial struct RecordHistoryId;
