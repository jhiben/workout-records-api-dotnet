using StronglyTypedIds;
using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public abstract class RecordHistory : Entity<RecordHistoryId>, IAggregateRoot
{
    private readonly List<object> _uncommittedEvents = new();

    protected RecordHistory(RecordHistoryId id)
        : base(id) { }

    public static RepsRecordHistory ForReps(WorkoutId workoutId) => new(workoutId);

    public static TimeRecordHistory ForTime(WorkoutId workoutId) => new(workoutId);

    public static WeightRecordHistory ForWeight(WorkoutId workoutId) => new(workoutId);

    public IReadOnlyList<object> GetUncommittedEvents() => _uncommittedEvents;

    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();

    protected void RaiseEvent(object @event)
    {
        _uncommittedEvents.Add(@event);
        ApplyEvent(@event);
    }

    protected abstract void ApplyEvent(object @event);
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

        RaiseEvent(new RecordSetEvent<T>(record));
    }

    protected override void ApplyEvent(object @event)
    {
        switch (@event)
        {
            case RecordSetEvent<T> e:
                _records.Add(e.Record);
                break;
        }
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

public class RecordSetEvent<T>
{
    public RecordSetEvent(T record)
    {
        Record = record;
    }

    public T Record { get; }
}

[StronglyTypedId(converters: StronglyTypedIdConverter.None)]
public partial struct RecordHistoryId;
