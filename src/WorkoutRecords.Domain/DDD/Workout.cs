using StronglyTypedIds;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Workout : Entity<WorkoutId>
{
    private Workout()
        : this(WorkoutId.New()) { }

    private Workout(WorkoutId id)
        : base(id) { }
}

[StronglyTypedId(converters: StronglyTypedIdConverter.None)]
public partial struct WorkoutId { }
