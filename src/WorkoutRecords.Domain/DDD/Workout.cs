using StronglyTypedIds;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Workout : Entity<WorkoutId>, IAggregateRoot
{
    private readonly List<WorkoutMovement> _movements = [];
    private readonly List<object> _uncommittedEvents = new();

    private Workout(WorkoutId id, Name name, Time timeCap, Rounds rounds)
        : base(id)
    {
        Name = name;
        TimeCap = timeCap;
        Rounds = rounds;
    }

    public Name Name { get; }

    public Time TimeCap { get; }

    public Rounds Rounds { get; }

    public IReadOnlyList<WorkoutMovement> Movements => _movements;

    public static Workout Prepare(Name name, Time timeCap, Rounds rounds) =>
        new(WorkoutId.New(), name, timeCap, rounds);

    public void Comprise(WorkoutMovement movement)
    {
        RaiseEvent(new WorkoutMovementAddedEvent(movement));
    }

    public IReadOnlyList<object> GetUncommittedEvents() => _uncommittedEvents;

    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();

    private void RaiseEvent(object @event)
    {
        _uncommittedEvents.Add(@event);
        ApplyEvent(@event);
    }

    private void ApplyEvent(object @event)
    {
        switch (@event)
        {
            case WorkoutMovementAddedEvent e:
                _movements.Add(e.Movement);
                break;
        }
    }
}

public class WorkoutMovementAddedEvent
{
    public WorkoutMovementAddedEvent(WorkoutMovement movement)
    {
        Movement = movement;
    }

    public WorkoutMovement Movement { get; }
}

[StronglyTypedId(converters: StronglyTypedIdConverter.None)]
public partial struct WorkoutId { }
