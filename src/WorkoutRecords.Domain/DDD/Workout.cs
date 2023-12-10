using StronglyTypedIds;

namespace WorkoutRecords.Domain.DDD;

public class Workout
{
    public WorkoutId Id { get; } = WorkoutId.New();
}

[StronglyTypedId(converters: StronglyTypedIdConverter.None)]
public partial struct WorkoutId { }
