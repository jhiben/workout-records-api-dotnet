using StronglyTypedIds;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Workout : Entity<WorkoutId>, IAggregateRoot
{
    private readonly List<WorkoutMovement> _movements = [];

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

    public void Comprise(WorkoutMovement movement) => _movements.Add(movement);
}

[StronglyTypedId(converters: StronglyTypedIdConverter.None)]
public partial struct WorkoutId { }
